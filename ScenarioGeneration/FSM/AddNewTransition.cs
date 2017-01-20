using System;
using NMF.SynchronizationsBenchmark.FiniteStateMachines;
using NMF.SynchronizationsBenchmark.Runtime;
using System.Collections.Generic;

namespace NMF.SynchronizationsBenchmark.ScenarioGeneration.FSM
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

        public override void Perform(FiniteStateMachine fsm, DeltaSpecification delta)
        {
            var t = new Transition()
            {
                Input = Input,
                StartState = fsm.States[StartStateIndex],
                EndState = fsm.States[EndStateIndex]
            };

            delta.AddedNodes.Add(t);
            delta.AddedEdges.Add(new EMoflonEdge()
            {
                Src = fsm,
                Trg = t,
                Name = "transitions"
            });
            delta.AddedEdges.Add(new EMoflonEdge()
            {
                Src = t,
                Trg = t.EndState,
                Name = "startState"
            });
            delta.AddedEdges.Add(new EMoflonEdge()
            {
                Src = t,
                Trg = t.EndState,
                Name = "endState"
            });
        }

        public override int Index
        {
            get { return 1; }
        }
    }
}
