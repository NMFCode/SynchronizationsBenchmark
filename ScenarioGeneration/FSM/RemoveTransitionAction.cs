using NMF.SynchronizationsBenchmark.FiniteStateMachines;
using System;
using NMF.SynchronizationsBenchmark.Runtime;
using System.Collections.Generic;

namespace NMF.SynchronizationsBenchmark.ScenarioGeneration.FSM
{
    class RemoveTransitionAction : FSMWorkloadAction
    {
        public int TransitionIndex { get; set; }

        public override void Perform(FiniteStateMachine fsm)
        {
            TransitionIndex = Math.Min(TransitionIndex, fsm.Transitions.Count - 1);
            var t = fsm.Transitions[TransitionIndex];
            t.StartState = null;
            t.EndState = null;
            fsm.Transitions.RemoveAt(TransitionIndex);
        }

        public override void Perform(FiniteStateMachine fsm, DeltaSpecification delta)
        {
            TransitionIndex = Math.Min(TransitionIndex, fsm.Transitions.Count - 1);
            var t = fsm.Transitions[TransitionIndex];
            t.StartState = null;
            t.EndState = null;
            delta.DeletedNodes.Add(t);
            delta.DeletedEdges.Add(new EMoflonEdge()
            {
                Src = fsm,
                Trg = t,
                Name = "transitions"
            });
        }

        public override int Index
        {
            get { return 3; }
        }
    }
}
