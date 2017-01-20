using System;
using NMF.SynchronizationsBenchmark.FiniteStateMachines;
using NMF.SynchronizationsBenchmark.PetriNets;
using NMF.SynchronizationsBenchmark.Runtime;
using System.Collections.Generic;

namespace NMF.SynchronizationsBenchmark.ScenarioGeneration
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

        public abstract void Perform(FiniteStateMachine fsm, DeltaSpecification delta);

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
        public abstract void Perform(PetriNet net);
    }
}
