using NMF.SynchronizationsBenchmark.FiniteStateMachines;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NMF.SynchronizationsBenchmark.ScenarioGeneration.FSM
{
    public static class StateMachineGenerator
    {
        private static string[] __inputs = { "a", "b", "c", "d", "e", "f" };

        public static FiniteStateMachine GenerateStateMachine(string id, int states, double transitionsPerState, double endStateProbability)
        {
            var fsm = new FiniteStateMachine();
            var rand = new Random();
            fsm.Id = id;

            for (int i = 0; i < states; i++)
            {
                var state = new State()
                {
                    Name = "q" + i.ToString(),
                    IsEndState = rand.NextDouble() < endStateProbability
                };
                fsm.States.Add(state);
            }

            var transitions = (int)Math.Floor(states * transitionsPerState + 0.5);
            for (int i = 0; i < transitions; i++)
            {
                IState start;
                IState end;
                string input;
                do
                {
                    start = fsm.States[rand.Next(fsm.States.Count)];
                    end = fsm.States[rand.Next(fsm.States.Count)];
                    input = __inputs[rand.Next(__inputs.Length)];
                } while (start.Transitions.Any(t => t.Input == input));
                var transition = new Transition()
                {
                    StartState = start,
                    EndState = end,
                    Input = input
                };
                fsm.Transitions.Add(transition);
            }

            return fsm;
        }

        internal static List<FSMWorkloadAction> GenerateChangeWorkload(FiniteStateMachine initial, int workloadItems)
        {
            var rand = new Random();
            var workload = new List<FSMWorkloadAction>();
            var states = initial.States.Count;
            var transitions = initial.Transitions.Count;
            var machineNameCounter = 2;
            var stateNameCounter = initial.States.Count;
            var inputCounter = 1;
            for (int i = 0; i < workloadItems; i++)
            {
                var dice = rand.NextDouble();
                if (dice < 0.10 && states >= 0)
                {
                    // Remove state
                    workload.Add(new RemoveStateAction()
                    {
                        StateIndex = rand.Next(states)
                    });
                    states--;
                    transitions = Math.Max(0, transitions - 2 * __inputs.Length);
                }
                else if (dice < 0.40)
                {
                    // Add new state
                    workload.Add(new AddNewStateAction()
                    {
                        Name = "q" + stateNameCounter.ToString(),
                        IsEndState = rand.NextDouble() > 0.70
                    });
                    stateNameCounter++;
                    states++;
                }
                else if (dice < 0.50 && transitions >= 0)
                {
                    // Remove transition
                    workload.Add(new RemoveTransitionAction()
                    {
                        TransitionIndex = rand.Next(transitions)
                    });
                    transitions--;
                }
                else if (dice < 0.80 && states >= 0)
                {
                    // Add new transition
                    workload.Add(new AddNewTransition()
                    {
                        StartStateIndex = rand.Next(states),
                        EndStateIndex = rand.Next(states),
                        Input = "i" + inputCounter.ToString()
                    });
                    inputCounter++;
                    transitions++;
                }
                else if (dice < 0.85 && states >= 0)
                {
                    // Toggle end state
                    workload.Add(new ToggleEndStateAction()
                    {
                        StateIndex = rand.Next(states)
                    });
                }
                else if (dice < 0.90 && transitions >= 0 && states >= 0)
                {
                    // Reroute transition
                    workload.Add(new RetargetTransition()
                    {
                        TransitionIndex = rand.Next(transitions),
                        NewTargetStateIndex = rand.Next(states)
                    });
                }
                else if (dice < 0.99 && states >= 0)
                {
                    // Rename state
                    workload.Add(new RenameStateAction()
                    {
                        StateIndex = rand.Next(states),
                        NewName = "q" + stateNameCounter.ToString()
                    });
                    stateNameCounter++;
                }
                else
                {
                    // Rename machine
                    workload.Add(new RenameMachineAction()
                    {
                        Name = initial.Id + machineNameCounter.ToString()
                    });
                    machineNameCounter++;
                }
            }
            return workload;
        }
    }
}
