using NMF.Collections.ObjectModel;
using NMF.Expressions;
using NMF.Models.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace NMF.Synchronizations.Demo.FSM
{

    public class FiniteStateMachine : INotifyPropertyChanged
    {
        public IListExpression<State> States { get; private set; }
        public IListExpression<Transition> Transitions { get; private set; }

        #region Id

        private string mId;

        public string Id
        {
            get
            {
                return mId;
            }
            set
            {
                if (mId != value)
                {
                    mId = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        #endregion

        public FiniteStateMachine()
        {
            States = new ObservableList<State>();
            Transitions = new ObservableList<Transition>();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public FiniteStateMachine Copy()
        {
            var fsm = new FiniteStateMachine()
            {
                Id = Id
            };

            var statesDict = new Dictionary<string, State>();

            foreach (var state in States)
            {
                var newState = new State()
                {
                    IsEndState = state.IsEndState,
                    IsStartState = state.IsStartState,
                    Name = state.Name
                };
                statesDict.Add(newState.Name, newState);
                fsm.States.Add(newState);
            }

            foreach (var t in Transitions)
            {
                var newTransition = new Transition()
                {
                    Input = t.Input
                };
                newTransition.StartState = statesDict[t.StartState.Name];
                newTransition.EndState = statesDict[t.EndState.Name];
                newTransition.StartState.Transitions.Add(newTransition);
                fsm.Transitions.Add(newTransition);
            }

            return fsm;
        }


        public bool Match(FiniteStateMachine otherFsm)
        {
            var statesByName = otherFsm.States.ToDictionary(p => p.Name);

            if (Id != otherFsm.Id) return false;
            if (States.Count != otherFsm.States.Count) return false;
            if (Transitions.Count != otherFsm.Transitions.Count) return false;

            foreach (var state in States)
            {
                State otherState;
                if (!statesByName.TryGetValue(state.Name, out otherState) || otherState == null)
                {
                    return false;
                }

                if (state.IsEndState != otherState.IsEndState) return false;

                foreach (var transition in state.Transitions)
                {
                    if (!otherState.Transitions.Any(otherTransition =>
                    {
                        if (transition.Input != otherTransition.Input) return false;
                        return otherTransition.EndState == statesByName[transition.EndState.Name];
                    }))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    [DebuggerDisplay("State {Name}")]
    public class State : INotifyPropertyChanged
    {
        #region IsStartState

        private bool isStartState;

        public bool IsStartState
        {
            get
            {
                return isStartState;
            }
            set
            {
                if (isStartState != value)
                {
                    isStartState = value;
                    OnPropertyChanged("IsStartState");
                }
            }
        }

        #endregion

        #region IsEndState

        private bool isEndState;

        public bool IsEndState
        {
            get
            {
                return isEndState;
            }
            set
            {
                if (isEndState != value)
                {
                    isEndState = value;
                    OnPropertyChanged("IsEndState");
                }
            }
        }

        #endregion

        #region Name

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        #endregion

        public ObservableList<Transition> Transitions { get; private set; }

        public State()
        {
            Transitions = new StateTransitionCollection(this);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }

    [DebuggerDisplay("{Representation}")]
    public class Transition : INotifyPropertyChanged
    {
        #region StartState

        private State startState;

        public State StartState
        {
            get
            {
                return startState;
            }
            set
            {
                if (startState != value)
                {
                    var old = startState;
                    startState = value;
                    if (old != null) old.Transitions.Remove(this);
                    if (value != null && !value.Transitions.Contains(this)) value.Transitions.Add(this);
                    OnPropertyChanged("StartState");
                }
            }
        }

        #endregion

        #region EndState

        private State endState;

        public State EndState
        {
            get
            {
                return endState;
            }
            set
            {
                if (endState != value)
                {
                    endState = value;
                    OnPropertyChanged("EndState");
                }
            }
        }

        #endregion

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
                var start = startState != null ? startState.Name : "<null>";
                var end = endState != null ? endState.Name : "<null>";
                return start + " --(" + Input + ")-> " + end;
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class StateTransitionCollection : ObservableOppositeList<State, Transition>
    {
        public StateTransitionCollection(State parent) : base(parent) { }

        protected override void SetOpposite(Transition item, State newParent)
        {
            item.StartState = newParent;
        }
    }

}
