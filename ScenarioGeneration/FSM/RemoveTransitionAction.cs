using NMF.Synchronizations.Demo.FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMF.Synchronizations.Demo.ScenarioGeneration.FSM
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

        public override int Index
        {
            get { return 3; }
        }
    }
}
