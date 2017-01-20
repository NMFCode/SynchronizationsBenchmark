using System;
using NMF.SynchronizationsBenchmark.FiniteStateMachines;
using NMF.SynchronizationsBenchmark.Runtime;
using System.Collections.Generic;

namespace NMF.SynchronizationsBenchmark.ScenarioGeneration.FSM
{
    class AddNewStateAction : FSMWorkloadAction
    {
        public string Name { get; set; }

        public bool IsEndState { get; set; }

        public override void Perform(FiniteStateMachine fsm)
        {
            fsm.States.Add(new State() { Name = Name, IsEndState = IsEndState });
        }

        public override void Perform(FiniteStateMachine fsm, DeltaSpecification delta)
        {
            var s = new State() { Name = Name, IsEndState = IsEndState };
            delta.AddedNodes.Add(s);
            delta.AddedEdges.Add(new EMoflonEdge()
            {
                Name = "states",
                Src = fsm,
                Trg = s
            });
        }

        public override int Index
        {
            get { return 0; }
        }
    }
}
