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
    /// The public interface for ModelgeneratorRuleResult
    /// </summary>
    [DefaultImplementationTypeAttribute(typeof(ModelgeneratorRuleResult))]
    [XmlDefaultImplementationTypeAttribute(typeof(ModelgeneratorRuleResult))]
    public interface IModelgeneratorRuleResult : NMF.Models.IModelElement, IRuleResult
    {
        
        /// <summary>
        /// The performCount property
        /// </summary>
        int PerformCount
        {
            get;
            set;
        }
        
        /// <summary>
        /// The sourceObjects property
        /// </summary>
        IOrderedSetExpression<NMF.Models.IModelElement> SourceObjects
        {
            get;
        }
        
        /// <summary>
        /// The targetObjects property
        /// </summary>
        IOrderedSetExpression<NMF.Models.IModelElement> TargetObjects
        {
            get;
        }
        
        /// <summary>
        /// The corrObjects property
        /// </summary>
        IOrderedSetExpression<NMF.Models.IModelElement> CorrObjects
        {
            get;
        }
        
        /// <summary>
        /// Gets fired before the PerformCount property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> PerformCountChanging;
        
        /// <summary>
        /// Gets fired when the PerformCount property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> PerformCountChanged;
    }
}

