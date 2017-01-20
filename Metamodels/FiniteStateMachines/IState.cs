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
    /// The public interface for State
    /// </summary>
    [DefaultImplementationTypeAttribute(typeof(State))]
    [XmlDefaultImplementationTypeAttribute(typeof(State))]
    public interface IState : IModelElement
    {
        
        /// <summary>
        /// The isEndState property
        /// </summary>
        bool IsEndState
        {
            get;
            set;
        }
        
        /// <summary>
        /// The isStartState property
        /// </summary>
        bool IsStartState
        {
            get;
            set;
        }
        
        /// <summary>
        /// The name property
        /// </summary>
        string Name
        {
            get;
            set;
        }
        
        /// <summary>
        /// The transitions property
        /// </summary>
        IOrderedSetExpression<ITransition> Transitions
        {
            get;
        }
        
        /// <summary>
        /// Gets fired before the IsEndState property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> IsEndStateChanging;
        
        /// <summary>
        /// Gets fired when the IsEndState property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> IsEndStateChanged;
        
        /// <summary>
        /// Gets fired before the IsStartState property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> IsStartStateChanging;
        
        /// <summary>
        /// Gets fired when the IsStartState property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> IsStartStateChanged;
        
        /// <summary>
        /// Gets fired before the Name property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> NameChanging;
        
        /// <summary>
        /// Gets fired when the Name property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> NameChanged;
    }
}

