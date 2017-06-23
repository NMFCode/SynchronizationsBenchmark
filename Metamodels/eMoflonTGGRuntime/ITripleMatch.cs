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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace NMF.SynchronizationsBenchmark.Runtime
{
    
    
    /// <summary>
    /// The public interface for TripleMatch
    /// </summary>
    [DefaultImplementationTypeAttribute(typeof(TripleMatch))]
    [XmlDefaultImplementationTypeAttribute(typeof(TripleMatch))]
    public interface ITripleMatch : NMF.Models.IModelElement
    {
        
        /// <summary>
        /// The ruleName property
        /// </summary>
        string RuleName
        {
            get;
            set;
        }
        
        /// <summary>
        /// The number property
        /// </summary>
        int Number
        {
            get;
            set;
        }
        
        /// <summary>
        /// The sourceElements property
        /// </summary>
        IOrderedSetExpression<NMF.Models.IModelElement> SourceElements
        {
            get;
        }
        
        /// <summary>
        /// The contextElements property
        /// </summary>
        IOrderedSetExpression<NMF.Models.IModelElement> ContextElements
        {
            get;
        }
        
        /// <summary>
        /// The nodeMappings property
        /// </summary>
        IOrderedSetExpression<ITripleMatchNodeMapping> NodeMappings
        {
            get;
        }
        
        /// <summary>
        /// The containedEdges property
        /// </summary>
        IOrderedSetExpression<NMF.Models.IModelElement> ContainedEdges
        {
            get;
        }
        
        /// <summary>
        /// The targetElements property
        /// </summary>
        IOrderedSetExpression<NMF.Models.IModelElement> TargetElements
        {
            get;
        }
        
        /// <summary>
        /// The correspondenceElements property
        /// </summary>
        IOrderedSetExpression<NMF.Models.IModelElement> CorrespondenceElements
        {
            get;
        }
        
        /// <summary>
        /// The createdElements property
        /// </summary>
        IOrderedSetExpression<NMF.Models.IModelElement> CreatedElements
        {
            get;
        }
        
        /// <summary>
        /// The children property
        /// </summary>
        IOrderedSetExpression<ITripleMatch> Children
        {
            get;
        }
        
        /// <summary>
        /// Gets fired before the RuleName property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> RuleNameChanging;
        
        /// <summary>
        /// Gets fired when the RuleName property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> RuleNameChanged;
        
        /// <summary>
        /// Gets fired before the Number property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> NumberChanging;
        
        /// <summary>
        /// Gets fired when the Number property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> NumberChanged;
    }
}

