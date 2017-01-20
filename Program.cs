using NMF.SynchronizationsBenchmark.ScenarioGeneration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using NMF.SynchronizationsBenchmark.ScenarioGeneration.FSM;
using NMF.Transformations;
using FSM = NMF.SynchronizationsBenchmark.FiniteStateMachines;
using PN = NMF.SynchronizationsBenchmark.PetriNets;
using NMF.Synchronizations;
using NMF.Models.Repository;
using NMF.Models;
using System.Globalization;

namespace NMF.SynchronizationsBenchmark
{
    class Program
    {
        private static TransformationsImplementation fsm2pnTransformation = new TransformationsImplementation();
        private static SynchronizationsImplementation fsm2pnSynchronization = new SynchronizationsImplementation();

        private static string[] actions = { "AddState", "AddTransition", "RemoveState", "RemoveTransition", "RenameMachine", "RenameState", "RetargetTransition", "ToggleEndState" };

        static void Main(string[] args)
        {
            Console.WriteLine("Stopwatch accuracy on this machine is {0}hz, i.e. 1 tick = {1}ns", Stopwatch.Frequency, (1.0e9 / Stopwatch.Frequency));
            // Measure(sizes: new [] { 10 }, iterations: 5, workloadSize: 100);
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
            var times = new long[sizes.Length, iterations, 8];

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
            var repository = new ModelRepository();
            var fsm = StateMachineGenerator.GenerateStateMachine("Test", n, 2, 0.1);
            repository.Save(fsm, @"..\..\eMoflon\FiniteStatesToPetriNets\instances\fsm.xmi");
            var startRule = fsm2pnSynchronization.SynchronizationRule<SynchronizationsImplementation.AutomataToNet>();

            var watch = new Stopwatch();

            watch.Start();
            var transformationsPN = TransformationEngine.Transform<FSM.IFiniteStateMachine, PN.PetriNet>(fsm, fsm2pnTransformation);
            watch.Stop();
            times[sizeIdx, iteration, 0] = watch.Elapsed.Ticks;

            PN.PetriNet batchNet = null;
            FSM.FiniteStateMachine batchMachine = fsm.Copy();
            watch.Restart();
            fsm2pnSynchronization.Synchronize(startRule, ref batchMachine, ref batchNet, SynchronizationDirection.LeftToRightForced, ChangePropagationMode.None);
            watch.Stop();
            times[sizeIdx, iteration, 1] = watch.Elapsed.Ticks;
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
            times[sizeIdx, iteration, 2] = watch.Elapsed.Ticks;
            if (!transformationsPN.Match(incNet))
            {
                Console.WriteLine("Incremental synchronization result is wrong.");
                Debugger.Break();
            }

            var ntlMachine = fsm.Copy();
            var workload = StateMachineGenerator.GenerateChangeWorkload(fsm, workloadSize);
            transformationsPN = PlayTransformations(times, sizeIdx, iteration, ntlMachine, watch, transformationsPN, workload);
            sumPoll += watch.Elapsed.Ticks;

            PlayBatchNet(times, sizeIdx, iteration, startRule, watch, ref batchNet, ref batchMachine, workload);

            PlayIncremental(times, sizeIdx, iteration, watch, incMachine, workload);
            sumInc += watch.ElapsedTicks;

            WorkloadConverter.ConvertAndSave(fsm, workload, @"..\..\eMoflon\FiniteStatesToPetriNets\instances\delta{0}.xmi");
            CallEMoflon(times, sizeIdx, iteration);

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

        private static void CallEMoflon(long[,,] times, int sizeIdx, int iteration)
        {
            var processInfo = new ProcessStartInfo()
            {
                FileName = "java",
                Arguments = @"-jar ..\FiniteStatesToPetriNets.jar",
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = Path.GetFullPath(@"..\..\eMoflon\FiniteStatesToPetriNets"),
                UseShellExecute = false
            };
            var process = Process.Start(processInfo);
            var initial = process.StandardOutput.ReadLine();
            var updates = process.StandardOutput.ReadLine();
            process.StandardOutput.ReadToEnd();
            Console.Error.Write(process.StandardError.ReadToEnd());
            if (process.ExitCode == 0)
            {
                times[sizeIdx, iteration, 6] = long.Parse(initial) / 100;
                times[sizeIdx, iteration, 7] = long.Parse(updates) / 100;
            }
            else
            {
                times[sizeIdx, iteration, 6] = -1;
                times[sizeIdx, iteration, 7] = -1;
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
            times[sizeIdx, iteration, 5] = watch.Elapsed.Ticks;
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
            times[sizeIdx, iteration, 4] = watch.Elapsed.Ticks;
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
            times[sizeIdx, iteration, 3] = watch.Elapsed.Ticks;
            return transformationsPN;
        }

        private static void RerunBatchSynchronization(SynchronizationsImplementation.AutomataToNet startRule, ref PN.PetriNet batchNet, ref FSM.FiniteStateMachine batchMachine)
        {
            batchNet = null;
            fsm2pnSynchronization.Synchronize(startRule, ref batchMachine, ref batchNet, SynchronizationDirection.LeftToRightForced, ChangePropagationMode.None);
        }

        private static PN.PetriNet RerunTransformation(FSM.FiniteStateMachine fsm, PN.PetriNet transformationsPN)
        {
            return TransformationEngine.Transform<FSM.IFiniteStateMachine, PN.PetriNet>(fsm, fsm2pnTransformation);
        }

        /// <summary>
        /// Writes the results to a file
        /// </summary>
        private static void WriteResultsToCsv(int[] sizes, int iterations, long[, ,] times)
        {
            using (var sw = new StreamWriter("results.csv"))
            {
                sw.Write("Size;Iteration;");
                sw.WriteLine(@"""Init Transformation"";""Init Batch Synchronization"";""Init Incremental Synchronization"";""Main Transformation"";""Main Batch Synchronization"";""Main Incremental Synchronization"";""Init eMoflon"";""Main eMoflon""");
                for (int sizeIdx = 0; sizeIdx < sizes.Length; sizeIdx++)
                {
                    var n = sizes[sizeIdx];
                    for (int iteration = 0; iteration < iterations; iteration++)
                    {
                        sw.Write("{0};{1}", n, iteration);
                        for (int i = 0; i <= 7; i++)
                        {
                            sw.Write(";");
                            sw.Write((times[sizeIdx, iteration, i] / 10000.0).ToString("0.000", CultureInfo.InvariantCulture));
                        }
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}
