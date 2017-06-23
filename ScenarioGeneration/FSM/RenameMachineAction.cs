using System;
using System.Collections.Generic;
using NMF.SynchronizationsBenchmark.FiniteStateMachines;
using NMF.SynchronizationsBenchmark.Runtime;
using NMF.Models.Repository;
using NMF.Models.Meta;

namespace NMF.SynchronizationsBenchmark.ScenarioGeneration.FSM
{
    class RenameMachineAction : FSMWorkloadAction
    {
        public static IAttribute NameAttribute = (MetaRepository.Instance.ResolveClass(typeof(FiniteStateMachine)) as Class).LookupAttribute("id");
        public string Name { get; set; }

        public override void Perform(FiniteStateMachine fsm)
        {
            fsm.Id = Name;
        }

        public override void Perform(FiniteStateMachine fsm, DeltaSpecification delta)
        {
            delta.AttributeChanges.Add(new AttributeDelta()
            {
                AffectedNode = fsm,
                AffectedAttribute = NameAttribute,
                OldValue = fsm.Id,
                NewValue = Name
            });
        }

        public override int Index
        {
            get { return 4; }
        }
    }
}
