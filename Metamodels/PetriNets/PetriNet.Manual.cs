using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMF.SynchronizationsBenchmark.PetriNets
{
    public partial class PetriNet
    {
        public bool Match(PetriNet otherNet)
        {
            if (otherNet == null) return false;

            var placesByName = otherNet.Places.ToDictionary(p => p.Id);

            if (Id != otherNet.Id) return false;
            if (Places.Count != otherNet.Places.Count) return false;
            if (Transitions.Count != otherNet.Transitions.Count) return false;

            foreach (var place in Places)
            {
                if (!placesByName.TryGetValue(place.Id, out IPlace otherPlace) || otherPlace == null)
                {
                    return false;
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
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
