using System;
using System.Collections.Generic;
using NMF.SynchronizationsBenchmark.FiniteStateMachines;
using NMF.SynchronizationsBenchmark.Runtime;

namespace NMF.SynchronizationsBenchmark.ScenarioGeneration.FSM
{
    class RetargetTransition : FSMWorkloadAction
    {
        public int TransitionIndex { get; set; }

        public int NewTargetStateIndex { get; set; }

        public override void Perform(FiniteStateMachine fsm)
        {
            var t = fsm.Transitions[TransitionIndex];
            t.EndState = fsm.States[NewTargetStateIndex];
        }

        public override void Perform(FiniteStateMachine fsm, DeltaSpecification delta)
        {
            var t = fsm.Transitions[TransitionIndex];
            var newEnd = fsm.States[NewTargetStateIndex];
            if (t.StartState == newEnd) return;
            delta.DeletedEdges.Add(new EMoflonEdge()
            {
                Src = t,
                Trg = t.EndState,
                Name = "endState"
            });
            delta.AddedEdges.Add(new EMoflonEdge()
            {
                Src = t,
                Trg = newEnd,
                Name = "endState"
            });
            t.EndState = newEnd;
        }

        public override int Index
        {
            get { return 6; }
        }
    }
}
