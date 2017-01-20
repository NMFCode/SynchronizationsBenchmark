//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using NMF.Collections.Generic;
using NMF.Collections.ObjectModel;
using NMF.Expressions;
using NMF.Expressions.Linq;
using NMF.Models;
using NMF.Models.Collections;
using NMF.Models.Expressions;
using NMF.Models.Meta;
using NMF.Models.Repository;
using NMF.Serialization;
using NMF.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace NMF.SynchronizationsBenchmark.FiniteStateMachines
{
    
    
    /// <summary>
    /// The public interface for Transition
    /// </summary>
    [DefaultImplementationTypeAttribute(typeof(Transition))]
    [XmlDefaultImplementationTypeAttribute(typeof(Transition))]
    public interface ITransition : IModelElement
    {
        
        /// <summary>
        /// The input property
        /// </summary>
        string Input
        {
            get;
            set;
        }
        
        /// <summary>
        /// The startState property
        /// </summary>
        IState StartState
        {
            get;
            set;
        }
        
        /// <summary>
        /// The endState property
        /// </summary>
        IState EndState
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets fired before the Input property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> InputChanging;
        
        /// <summary>
        /// Gets fired when the Input property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> InputChanged;
        
        /// <summary>
        /// Gets fired before the StartState property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> StartStateChanging;
        
        /// <summary>
        /// Gets fired when the StartState property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> StartStateChanged;
        
        /// <summary>
        /// Gets fired before the EndState property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> EndStateChanging;
        
        /// <summary>
        /// Gets fired when the EndState property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> EndStateChanged;
    }
}
