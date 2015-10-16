using NMF.Synchronizations.Demo.FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMF.Synchronizations.Demo.ScenarioGeneration.FSM
{
    class RenameMachineAction : FSMWorkloadAction
    {
        public string Name { get; set; }

        public override void Perform(FiniteStateMachine fsm)
        {
            fsm.Id = Name;
        }

        public override int Index
        {
            get { return 4; }
        }
    }
}
