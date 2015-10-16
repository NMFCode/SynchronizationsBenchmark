using NMF.Synchronizations.Demo.FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMF.Synchronizations.Demo.ScenarioGeneration.FSM
{
    class AddNewTransition : FSMWorkloadAction
    {
        public int StartStateIndex { get; set; }

        public int EndStateIndex { get; set; }

        public string Input { get; set; }

        public override void Perform(FiniteStateMachine fsm)
        {
            var t = new Transition()
            {
                Input = Input,
                StartState = fsm.States[StartStateIndex],
                EndState = fsm.States[EndStateIndex]
            };

            fsm.Transitions.Add(t);
        }

        public override int Index
        {
            get { return 1; }
        }
    }
}
