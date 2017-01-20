using System;
using System.Collections.Generic;
using NMF.SynchronizationsBenchmark.FiniteStateMachines;
using NMF.SynchronizationsBenchmark.Runtime;
using NMF.Interop.Ecore;
using NMF.Models.Meta;
using NMF.Models.Repository;

namespace NMF.SynchronizationsBenchmark.ScenarioGeneration.FSM
{
    class RenameStateAction : FSMWorkloadAction
    {
        public static IAttribute NameAttribute = (MetaRepository.Instance.ResolveClass(typeof(State)) as Class).LookupAttribute("name");
        public int StateIndex { get; set; }

        public string NewName { get; set; }

        public override void Perform(FiniteStateMachine fsm)
        {
            fsm.States[StateIndex].Name = NewName;
        }

        public override void Perform(FiniteStateMachine fsm, DeltaSpecification delta)
        {
            var s = fsm.States[StateIndex];
            delta.AttributeChanges.Add(new AttributeDelta()
            {
                AffectedAttribute = NameAttribute,
                AffectedNode = s,
                OldValue = s.Name,
                NewValue = NewName
            });
        }

        public override int Index
        {
            get { return 5; }
        }
    }
}
