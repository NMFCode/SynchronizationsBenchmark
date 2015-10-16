using NMF.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Linq;
using NMF.Models.Collections;
using NMF.Expressions;

namespace NMF.Synchronizations.Demo.PN
{
    public class PetriNet : INotifyPropertyChanged
    {
        public ISetExpression<Place> Places { get; private set; }
        public ISetExpression<Transition> Transitions { get; private set; }

        #region Id

        private string id;

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        #endregion

        public PetriNet()
        {
            Places = new ObservableSet<Place>();
            Transitions = new ObservableSet<Transition>();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Match(PetriNet otherNet)
        {
            if (otherNet == null) return __False();

            var placesByName = otherNet.Places.ToDictionary(p => p.Id);

            if (Id != otherNet.Id) return __False();
            if (Places.Count != otherNet.Places.Count) return __False();
            if (Transitions.Count != otherNet.Transitions.Count) return __False();

            foreach (var place in Places)
            {
                Place otherPlace;
                if (!placesByName.TryGetValue(place.Id, out otherPlace) || otherPlace == null)
                {
                    return __False();
                }

                foreach (var transition in place.Outgoing)
                {
                    if (!otherPlace.Outgoing.Any(otherTransition =>
                    {
                        if (transition.Input != otherTransition.Input) return false;
                        if (transition.To.Count != otherTransition.To.Count) return false;
                        foreach (var targetPlace in transition.To)
                        {
                            if (!otherTransition.To.Contains(placesByName[targetPlace.Id])) return false;
                        }
                        return true;
                    }))
                    {
                        return __False();
                    }
                }
            }

            return true;
        }

        private static bool __False()
        {
            Debugger.Break();
            return false;
        }
    }

    [DebuggerDisplay("Place {Id}")]
    public class Place : INotifyPropertyChanged
    {
        #region Id

        private string id;

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        #endregion

        public ISetExpression<Transition> Incoming { get; private set; }
        public ISetExpression<Transition> Outgoing { get; private set; }

        public Place()
        {
            Incoming = new PlaceIncomingCollection(this);
            Outgoing = new PlaceOutgoingCollection(this);
        }

        #region TokenCount

        private int tokenCount;

        public int TokenCount
        {
            get
            {
                return tokenCount;
            }
            set
            {
                if (tokenCount != value)
                {
                    tokenCount = value;
                    OnPropertyChanged("TokenCount");
                }
            }
        }

        #endregion
        

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    [DebuggerDisplay("{Representation}")]
    public class Transition : INotifyPropertyChanged
    {
        public ISetExpression<Place> From { get; private set; }
        public ISetExpression<Place> To { get; private set; }

        #region Input

        private string input;

        public string Input
        {
            get
            {
                return input;
            }
            set
            {
                if (input != value)
                {
                    input = value;
                    OnPropertyChanged("Input");
                }
            }
        }

        #endregion

        public string Representation
        {
            get
            {
                var start = string.Join(",", From.Select(p => p.Id));
                var end = string.Join(",", To.Select(p => p.Id));
                return string.Format("[{0}] --({1})-> [{2}]", start, input, end);
            }
        }
        

        public Transition()
        {
            From = new TransitionFromCollection(this);
            To = new TransitionToCollection(this);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class PlaceIncomingCollection : ObservableOppositeSet<Place, Transition>
    {
        public PlaceIncomingCollection(Place parent) : base(parent) { }

        protected override void SetOpposite(Transition item, Place newParent)
        {
            if (newParent != null)
            {
                item.To.Add(newParent);
            }
            else
            {
                item.To.Remove(Parent);
            }
        }
    }

    public class PlaceOutgoingCollection : ObservableOppositeSet<Place, Transition>
    {
        public PlaceOutgoingCollection(Place parent) : base(parent) { }

        protected override void SetOpposite(Transition item, Place newParent)
        {
            if (newParent != null)
            {
                item.From.Add(newParent);
            }
            else
            {
                item.From.Remove(Parent);
            }
        }
    }

    public class TransitionFromCollection : ObservableOppositeSet<Transition, Place>
    {
        public TransitionFromCollection(Transition parent) : base(parent) { }

        protected override void SetOpposite(Place item, Transition newParent)
        {
            if (newParent != null)
            {
                item.Outgoing.Add(newParent);
            }
            else
            {
                item.Outgoing.Remove(Parent);
            }
        }
    }

    public class TransitionToCollection : ObservableOppositeSet<Transition, Place>
    {
        public TransitionToCollection(Transition parent) : base(parent) { }

        protected override void SetOpposite(Place item, Transition newParent)
        {
            if (newParent != null)
            {
                item.Incoming.Add(newParent);
            }
            else
            {
                item.Incoming.Remove(Parent);
            }
        }
    }
}
