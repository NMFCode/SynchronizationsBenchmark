using NMF.Expressions.Linq;
using NMF.Transformations;
using NMF.Synchronizations;
using System;
using System.Collections.Generic;
using FSM = NMF.SynchronizationsBenchmark.FiniteStateMachines;
using PN = NMF.SynchronizationsBenchmark.PetriNets;

namespace NMF.SynchronizationsBenchmark
{
    public class SynchronizationsImplementation : ReflectiveSynchronization
    {
        public class AutomataToNet : SynchronizationRule<FSM.FiniteStateMachine, PN.PetriNet>
        {
            public override bool ShouldCorrespond(FSM.FiniteStateMachine left, PN.PetriNet right, ISynchronizationContext context)
            {
                return true;
            }

            public override void DeclareSynchronization()
            {
                SynchronizeMany(SyncRule<StateToPlace>(),
                    fsm => fsm.States, pn => pn.Places);

                SynchronizeMany(SyncRule<TransitionToTransition>(),
                    fsm => fsm.Transitions, pn => pn.Transitions.Where(t => t.To.Count > 0));

                SynchronizeMany(SyncRule<EndStateToTransition>(),
                    fsm => fsm.States.Where(state => state.IsEndState),
                    pn => pn.Transitions.Where(t => t.To.Count == 0));

                Synchronize(fsm => fsm.Id, pn => pn.Id);
            }
        }

        public class StateToPlace : SynchronizationRule<FSM.IState, PN.IPlace>
        {
            public override bool ShouldCorrespond(FSM.IState left, PN.IPlace right, ISynchronizationContext context)
            {
                return left.Name == right.Id;
            }

            public override void DeclareSynchronization()
            {
                Synchronize(state => state.Name, place => place.Id);
            }
        }

        public class TransitionToTransition : SynchronizationRule<FSM.ITransition, PN.ITransition>
        {

            public override void DeclareSynchronization()
            {
                Synchronize(t => t.Input, t => t.Input);

                Synchronize(SyncRule<StateToPlace>(),
                    t => t.StartState,
                    t => t.From.SingleOrDefault());

                Synchronize(SyncRule<StateToPlace>(),
                    t => t.EndState,
                    t => t.To.SingleOrDefault());
            }

            public override bool ShouldCorrespond(FSM.ITransition left, PN.ITransition right, ISynchronizationContext context)
            {
                var stateToPlace = SyncRule<StateToPlace>().LeftToRight;
                return left.Input == right.Input
                    && right.From.Contains(context.Trace.ResolveIn(stateToPlace, left.StartState))
                    && right.To.Contains(context.Trace.ResolveIn(stateToPlace, left.EndState));
            }
        }

        public class EndStateToTransition : SynchronizationRule<FSM.IState, PN.ITransition>
        {
            public override bool ShouldCorrespond(FSM.IState left, PN.ITransition right, ISynchronizationContext context)
            {
                return context.Trace.ResolveIn(SyncRule<StateToPlace>().LeftToRight, left) == right.From.FirstOrDefault();
            }

            protected override FSM.IState CreateLeftOutput(PN.ITransition transition, IEnumerable<FSM.IState> candidates, ISynchronizationContext context, out bool existing)
            {
                if (transition.From.Count == 0) throw new InvalidOperationException();
                existing = true;
                return context.Trace.ResolveIn(SyncRule<StateToPlace>().RightToLeft, transition.From.FirstOrDefault());
            }

            public override void DeclareSynchronization()
            {
                SynchronizeLeftToRightOnly(SyncRule<StateToPlace>(),
                    state => state.IsEndState ? state : null,
                    transition => transition.From.FirstOrDefault());
            }
        }
    }
}
