using NMF.Synchronizations.Demo.FSM;
using System.Collections.Generic;
using System.Text;

namespace NMF.Synchronizations.Demo.ScenarioGeneration
{
    /// <summary>
    /// The abstract base class for elements of a generated workload on finite state machines
    /// </summary>
    abstract class FSMWorkloadAction
    {
        /// <summary>
        /// Rund the workload on the given finite state machine
        /// </summary>
        /// <param name="fsm">The finite state machine</param>
        public abstract void Perform(FiniteStateMachine fsm);

        public abstract int Index { get; }
    }

    /// <summary>
    /// The abstract base class for elements of a generated workload on Petri Nets
    /// </summary>
    abstract class PNWorkloadAction
    {
        /// <summary>
        /// Run the workload on the given Petri net
        /// </summary>
        /// <param name="net">The Petri net</param>
        public abstract void Perform(PN.PetriNet net);
    }
}
