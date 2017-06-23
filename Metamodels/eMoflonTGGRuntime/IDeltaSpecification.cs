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
    /// The public interface for DeltaSpecification
    /// </summary>
    [DefaultImplementationTypeAttribute(typeof(DeltaSpecification))]
    [XmlDefaultImplementationTypeAttribute(typeof(DeltaSpecification))]
    public interface IDeltaSpecification : NMF.Models.IModelElement
    {
        
        /// <summary>
        /// The targetModel property
        /// </summary>
        NMF.Models.IModelElement TargetModel
        {
            get;
            set;
        }
        
        /// <summary>
        /// The addedEdges property
        /// </summary>
        IOrderedSetExpression<IEMoflonEdge> AddedEdges
        {
            get;
        }
        
        /// <summary>
        /// The deletedNodes property
        /// </summary>
        IOrderedSetExpression<NMF.Models.IModelElement> DeletedNodes
        {
            get;
        }
        
        /// <summary>
        /// The addedNodes property
        /// </summary>
        IOrderedSetExpression<NMF.Models.IModelElement> AddedNodes
        {
            get;
        }
        
        /// <summary>
        /// The deletedEdges property
        /// </summary>
        IOrderedSetExpression<IEMoflonEdge> DeletedEdges
        {
            get;
        }
        
        /// <summary>
        /// The attributeChanges property
        /// </summary>
        IOrderedSetExpression<IAttributeDelta> AttributeChanges
        {
            get;
        }
        
        /// <summary>
        /// Gets fired before the TargetModel property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> TargetModelChanging;
        
        /// <summary>
        /// Gets fired when the TargetModel property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> TargetModelChanged;
    }
}

