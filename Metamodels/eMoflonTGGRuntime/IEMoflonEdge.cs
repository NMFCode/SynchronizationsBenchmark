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
    /// The public interface for EMoflonEdge
    /// </summary>
    [DefaultImplementationTypeAttribute(typeof(EMoflonEdge))]
    [XmlDefaultImplementationTypeAttribute(typeof(EMoflonEdge))]
    public interface IEMoflonEdge : NMF.Models.IModelElement
    {
        
        /// <summary>
        /// The name property
        /// </summary>
        string Name
        {
            get;
            set;
        }
        
        /// <summary>
        /// The src property
        /// </summary>
        NMF.Models.IModelElement Src
        {
            get;
            set;
        }
        
        /// <summary>
        /// The trg property
        /// </summary>
        NMF.Models.IModelElement Trg
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets fired before the Name property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> NameChanging;
        
        /// <summary>
        /// Gets fired when the Name property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> NameChanged;
        
        /// <summary>
        /// Gets fired before the Src property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> SrcChanging;
        
        /// <summary>
        /// Gets fired when the Src property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> SrcChanged;
        
        /// <summary>
        /// Gets fired before the Trg property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> TrgChanging;
        
        /// <summary>
        /// Gets fired when the Trg property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> TrgChanged;
    }
}

