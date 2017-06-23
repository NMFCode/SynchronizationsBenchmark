using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMF.SynchronizationsBenchmark.FiniteStateMachines
{
    public partial class FiniteStateMachine
    {
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
                if (!statesByName.TryGetValue(state.Name, out IState otherState) || otherState == null)
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
}
