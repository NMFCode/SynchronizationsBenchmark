using NMF.Synchronizations.Demo.FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMF.Synchronizations.Demo.ScenarioGeneration.FSM
{
    class ToggleEndStateAction : FSMWorkloadAction
    {
        public int StateIndex { get; set; }

        public override void Perform(FiniteStateMachine fsm)
        {
            var state = fsm.States[StateIndex];
            state.IsEndState = !state.IsEndState;
        }

        public override int Index
        {
            get { return 7; }
        }
    }
}
