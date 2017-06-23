using NMF.Collections.ObjectModel;
using NMF.Expressions;
using NMF.Models;
using NMF.Models.Meta;
using NMF.Models.Repository;
using NMF.SynchronizationsBenchmark.FiniteStateMachines;
using NMF.SynchronizationsBenchmark.Runtime;
using NMF.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMF.SynchronizationsBenchmark.ScenarioGeneration
{
    static class WorkloadConverter
    {
        public static void ConvertAndSave(FiniteStateMachine fsm, List<FSMWorkloadAction> actions, string pathTemplate)
        {
            var repository = new ModelRepository();
            var i = 0;
            foreach (var action in actions)
            {
                var spec = new DeltaSpecification()
                {
                    TargetModel = fsm
                };
                action.Perform(fsm, spec);

                // we have to persist the delta spec exactly here
                repository.Save(spec, string.Format(pathTemplate, i));
                i++;

                // restore elements in their original location
                foreach (var s in spec.AddedNodes.OfType<State>().ToArray())
                {
                    fsm.States.Add(s);
                }
                foreach (var t in spec.AddedNodes.OfType<Transition>().ToArray())
                {
                    fsm.Transitions.Add(t);
                }
                // perform rename
                foreach (var delta in spec.AttributeChanges)
                {
                    if (delta.AffectedAttribute.Name == "id")
                    {
                        (delta.AffectedNode as FiniteStateMachine).Id = delta.NewValue;
                    }
                    else if (delta.AffectedAttribute.Name == "name")
                    {
                        (delta.AffectedNode as State).Name = delta.NewValue;
                    }
                    else if (delta.AffectedAttribute.Name == "isEndState")
                    {
                        var s = delta.AffectedNode as State;
                        s.IsEndState = !s.IsEndState;
                    }
                }
                // delete elements where the deletion has been suspended
                foreach (var node in spec.DeletedNodes.ToArray())
                {
                    node.Delete();
                }
            }
        }
    }
}
