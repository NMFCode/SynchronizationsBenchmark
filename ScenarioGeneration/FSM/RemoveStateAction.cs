using NMF.Synchronizations.Demo.FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMF.Synchronizations.Demo.ScenarioGeneration.FSM
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

        public override int Index
        {
            get { return 2; }
        }
    }
}
