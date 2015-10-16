using NMF.Synchronizations.Demo.FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMF.Synchronizations.Demo.ScenarioGeneration.FSM
{
    class AddNewStateAction : FSMWorkloadAction
    {
        public string Name { get; set; }

        public bool IsEndState { get; set; }

        public override void Perform(FiniteStateMachine fsm)
        {
            fsm.States.Add(new State() { Name = Name, IsEndState = IsEndState });
        }

        public override int Index
        {
            get { return 0; }
        }
    }
}
