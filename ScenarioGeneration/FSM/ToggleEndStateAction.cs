using System;
using NMF.Models.Meta;
using NMF.Models.Repository;
using NMF.SynchronizationsBenchmark.FiniteStateMachines;
using NMF.SynchronizationsBenchmark.Runtime;

namespace NMF.SynchronizationsBenchmark.ScenarioGeneration.FSM
{
    class ToggleEndStateAction : FSMWorkloadAction
    {
        public static IAttribute EndAttribute = (MetaRepository.Instance.ResolveClass(typeof(State)) as Class).LookupAttribute("isEndState");

        public int StateIndex { get; set; }

        public override void Perform(FiniteStateMachine fsm)
        {
            var state = fsm.States[StateIndex];
            state.IsEndState = !state.IsEndState;
        }

        public override void Perform(FiniteStateMachine fsm, DeltaSpecification delta)
        {
            var state = fsm.States[StateIndex];
            delta.AttributeChanges.Add(new AttributeDelta()
            {
                AffectedAttribute = EndAttribute,
                AffectedNode = state,
                OldValue = state.IsEndState ? "true" : "false",
                NewValue = state.IsEndState ? "false" : "true"
            });
        }

        public override int Index
        {
            get { return 7; }
        }
    }
}
