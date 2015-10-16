using NMF.Synchronizations.Demo.FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMF.Synchronizations.Demo.ScenarioGeneration.FSM
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

        public override int Index
        {
            get { return 6; }
        }
    }
}
