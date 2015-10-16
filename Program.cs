using NMF.Synchronizations.Demo.ScenarioGeneration;
using NMF.Expressions.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using NMF.Synchronizations.Demo.ScenarioGeneration.FSM;
using NMF.Transformations;
using NMF.Transformations.Core;

namespace NMF.Synchronizations.Demo
{
    class Program
    {
        private static TransformationsImplementation fsm2pnTransformation = new TransformationsImplementation();
        private static SynchronizationsImplementation fsm2pnSynchronization = new SynchronizationsImplementation();

        private static string[] actions = { "AddState", "AddTransition", "RemoveState", "RemoveTransition", "RenameMachine", "RenameState", "RetargetTransition", "ToggleEndState" };

        static void Main(string[] args)
        {
            Console.WriteLine("Stopwatch accuracy on this machine is {0}hz, i.e. 1 tick = {1}ns", Stopwatch.Frequency, (1.0e9 / Stopwatch.Frequency));
            Measure(sizes: new [] { 10, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 }, iterations: 50, workloadSize: 100);
        }

        /// <summary>
        /// Measures the polling algorithm versus the incremental algorithm for the given parameters
        /// </summary>
        /// <param name="sizes">The values for n</param>
        /// <param name="iterations">The amount of iterations</param>
        /// <param name="workloadSize">The workload size</param>
        private static void Measure(int[] sizes, int iterations, int workloadSize)
        {
            var times = new long[sizes.Length, iterations, 6];

            for (int sizeIdx = 0; sizeIdx < sizes.Length; sizeIdx++)
            {
                var n = sizes[sizeIdx];

                var sumPoll = 0L;
                var sumInc = 0L;

                for (int iteration = 0; iteration < iterations; iteration++)
                {
                    Console.WriteLine("Generating workload for n={0},iteration={1}...", n, iteration);
                    RunIteration(times, n, sizeIdx, iteration, workloadSize, ref sumPoll, ref sumInc);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

                Console.WriteLine("Average speedup for n={0}: {1:0.###}", n, ((double)sumPoll) / sumInc);
            }

            WriteResultsToCsv(sizes, iterations, times);
        }

        private static void RunIteration(long[, ,] times, int n, int sizeIdx, int iteration, int workloadSize, ref long sumPoll, ref long sumInc)
        {
            var fsm = StateMachineGenerator.GenerateStateMachine("Test", n, 2, 0.1);
            var startRule = fsm2pnSynchronization.SynchronizationRule<SynchronizationsImplementation.AutomataToNet>();

            var watch = new Stopwatch();

            watch.Start();
            var transformationsPN = TransformationEngine.Transform<FSM.FiniteStateMachine, PN.PetriNet>(fsm, fsm2pnTransformation);
            watch.Stop();
            times[sizeIdx, iteration, 0] = watch.ElapsedTicks;

            PN.PetriNet batchNet = null;
            FSM.FiniteStateMachine batchMachine = fsm.Copy();
            watch.Restart();
            fsm2pnSynchronization.Synchronize(startRule, ref batchMachine, ref batchNet, SynchronizationDirection.LeftToRightForced, ChangePropagationMode.None);
            watch.Stop();
            times[sizeIdx, iteration, 1] = watch.ElapsedTicks;
            if (!transformationsPN.Match(batchNet))
            {
                Console.WriteLine("Batch synchronization result is wrong.");
                Debugger.Break();
            }

            PN.PetriNet incNet = null;
            FSM.FiniteStateMachine incMachine = fsm.Copy();
            watch.Restart();
            fsm2pnSynchronization.Synchronize(startRule, ref incMachine, ref incNet, SynchronizationDirection.LeftToRightForced, ChangePropagationMode.OneWay);
            watch.Stop();
            times[sizeIdx, iteration, 2] = watch.ElapsedTicks;
            if (!transformationsPN.Match(incNet))
            {
                Console.WriteLine("Incremental synchronization result is wrong.");
                Debugger.Break();
            }

            var workload = StateMachineGenerator.GenerateChangeWorkload(fsm, workloadSize);
            transformationsPN = PlayTransformations(times, sizeIdx, iteration, fsm, watch, transformationsPN, workload);
            sumPoll += watch.ElapsedTicks;

            PlayBatchNet(times, sizeIdx, iteration, startRule, watch, ref batchNet, ref batchMachine, workload);

            PlayIncremental(times, sizeIdx, iteration, watch, incMachine, workload);
            sumInc += watch.ElapsedTicks;

            if (!transformationsPN.Match(batchNet))
            {
                Console.WriteLine("Batch synchronization result is wrong.");
                return;
            }
            if (!transformationsPN.Match(incNet))
            {
                Console.WriteLine("Incremental synchronization result is wrong.");
                return;
            }
        }

        private static void PlayIncremental(long[, ,] times, int sizeIdx, int iteration, Stopwatch watch, FSM.FiniteStateMachine incMachine, List<FSMWorkloadAction> workload)
        {
            watch.Restart();
            foreach (var item in workload)
            {
                item.Perform(incMachine);
            }
            watch.Stop();
            times[sizeIdx, iteration, 5] = watch.ElapsedTicks;
        }

        private static void PlayBatchNet(long[, ,] times, int sizeIdx, int iteration, SynchronizationsImplementation.AutomataToNet startRule, Stopwatch watch, ref PN.PetriNet batchNet, ref FSM.FiniteStateMachine batchMachine, List<FSMWorkloadAction> workload)
        {
            watch.Restart();
            foreach (var item in workload)
            {
                item.Perform(batchMachine);
                RerunBatchSynchronization(startRule, ref batchNet, ref batchMachine);
            }
            watch.Stop();
            times[sizeIdx, iteration, 4] = watch.ElapsedTicks;
        }

        private static PN.PetriNet PlayTransformations(long[, ,] times, int sizeIdx, int iteration, FSM.FiniteStateMachine fsm, Stopwatch watch, PN.PetriNet transformationsPN, List<FSMWorkloadAction> workload)
        {
            watch.Restart();
            foreach (var item in workload)
            {
                item.Perform(fsm);
                transformationsPN = RerunTransformation(fsm, transformationsPN);
            }
            watch.Stop();
            times[sizeIdx, iteration, 3] = watch.ElapsedTicks;
            return transformationsPN;
        }

        private static void RerunBatchSynchronization(SynchronizationsImplementation.AutomataToNet startRule, ref PN.PetriNet batchNet, ref FSM.FiniteStateMachine batchMachine)
        {
            batchNet = null;
            fsm2pnSynchronization.Synchronize(startRule, ref batchMachine, ref batchNet, SynchronizationDirection.LeftToRightForced, ChangePropagationMode.None);
        }

        private static PN.PetriNet RerunTransformation(FSM.FiniteStateMachine fsm, PN.PetriNet transformationsPN)
        {
            return TransformationEngine.Transform<FSM.FiniteStateMachine, PN.PetriNet>(fsm, fsm2pnTransformation);
        }

        /// <summary>
        /// Writes the results to a file
        /// </summary>
        private static void WriteResultsToCsv(int[] sizes, int iterations, long[, ,] times)
        {
            using (var sw = new StreamWriter("results.csv"))
            {
                sw.Write("Size;Iteration;");
                sw.WriteLine("Init Transformations;Init Batch Synchronization;Init Incremental Synchronization;Total(Transformations);Total(Batch);Total(Incremental);");
                for (int sizeIdx = 0; sizeIdx < sizes.Length; sizeIdx++)
                {
                    var n = sizes[sizeIdx];
                    for (int iteration = 0; iteration < iterations; iteration++)
                    {
                        sw.Write("{0};{1};", n, iteration);
                        for (int i = 0; i <= 5; i++)
                        {
                            sw.Write((times[sizeIdx, iteration, i] * 1000.0 / Stopwatch.Frequency).ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture));
                            sw.Write(";");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}
