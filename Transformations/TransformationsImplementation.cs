using NMF.Transformations;
using NMF.Transformations.Core;
using NMF.Utilities;
using System.Linq;
using FSM = NMF.SynchronizationsBenchmark.FiniteStateMachines;
using PN = NMF.SynchronizationsBenchmark.PetriNets;

namespace NMF.SynchronizationsBenchmark
{
    class TransformationsImplementation : ReflectiveTransformation
    {
        public class AutomataToNet : TransformationRule<FSM.IFiniteStateMachine, PN.PetriNet>
        {
            public override void Transform(FSM.IFiniteStateMachine input, PN.PetriNet output, ITransformationContext context)
            {
                output.Id = input.Id;
            }

            public override void RegisterDependencies()
            {
                RequireMany(Rule<State2Place>(), 
                    fsm => fsm.States, 
                    (pn, places) => pn.Places.AddRange(places));

                RequireMany(Rule<Transition2Transition>(), 
                    fsm => fsm.Transitions, 
                    (pn, transitions) => pn.Transitions.AddRange(transitions));

                RequireMany(Rule<EndStateToTransition>(), 
                    fsm => fsm.States.Where(s => s.IsEndState), 
                    (pn, endTransitions) => pn.Transitions.AddRange(endTransitions));
            }
        }

        public class State2Place : TransformationRule<FSM.IState, PN.Place>
        {
            public override void Transform(FSM.IState input, PN.Place output, ITransformationContext context)
            {
                output.Id = input.Name;
            }
        }

        public class Transition2Transition : TransformationRule<FSM.ITransition, PN.Transition>
        {
            public override void Transform(FSM.ITransition input, PN.Transition output, ITransformationContext context)
            {
                output.Input = input.Input;
            }

            public override void RegisterDependencies()
            {
                Require(Rule<State2Place>(),
                    t => t.StartState,
                    (t, place) => t.From.Add(place));

                Require(Rule<State2Place>(),
                    t => t.EndState,
                    (t, place) => t.To.Add(place));
            }
        }

        public class EndStateToTransition : TransformationRule<FSM.IState, PN.Transition>
        {
            public override void Transform(FSM.IState input, PN.Transition output, ITransformationContext context)
            {
                var place = context.Trace.ResolveIn(Rule<State2Place>(), input);
                place.Outgoing.Add(output);
            }
        }
    }
}
