using System;
using System.Collections.Generic;
using NMF.SynchronizationsBenchmark.FiniteStateMachines;
using NMF.SynchronizationsBenchmark.Runtime;

namespace NMF.SynchronizationsBenchmark.ScenarioGeneration.FSM
{
    class RemoveStateAction : FSMWorkloadAction
    {
        public int StateIndex { get; set; }

        public override void Perform(FiniteStateMachine fsm)
        {
            var state = fsm.States[StateIndex];
            for (int i = fsm.Transitions.Count - 1; i >= 0; i--)
            {
                var t = fsm.Transitions[i];
                if (t.StartState == state || t.EndState == state)
                {
                    fsm.Transitions.RemoveAt(i);
                }
            }
            state.Transitions.Clear();
            fsm.States.RemoveAt(StateIndex);
        }

        public override void Perform(FiniteStateMachine fsm, DeltaSpecification delta)
        {
            var state = fsm.States[StateIndex];
            for (int i = fsm.Transitions.Count - 1; i >= 0; i--)
            {
                var t = fsm.Transitions[i];
                if (t.StartState == state || t.EndState == state)
                {
                    delta.DeletedNodes.Add(t);
                    delta.DeletedEdges.Add(new EMoflonEdge()
                    {
                        Src = fsm,
                        Trg = t,
                        Name = "transitions"
                    });
                }
            }
            state.Transitions.Clear();
            delta.DeletedNodes.Add(state);
            delta.DeletedEdges.Add(new EMoflonEdge()
            {
                Src = fsm,
                Trg = state,
                Name = "states"
            });
        }

        public override int Index
        {
            get { return 2; }
        }
    }
}
