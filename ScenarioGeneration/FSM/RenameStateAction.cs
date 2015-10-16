using NMF.Synchronizations.Demo.FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMF.Synchronizations.Demo.ScenarioGeneration.FSM
{
    class RenameStateAction : FSMWorkloadAction
    {
        public int StateIndex { get; set; }

        public string NewName { get; set; }

        public override void Perform(FiniteStateMachine fsm)
        {
            fsm.States[StateIndex].Name = NewName;
        }

        public override int Index
        {
            get { return 5; }
        }
    }
}
