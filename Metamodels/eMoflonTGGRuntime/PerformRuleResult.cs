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
    /// The default implementation of the PerformRuleResult class
    /// </summary>
    [XmlNamespaceAttribute("platform:/plugin/org.moflon.tgg.runtime/model/Runtime.ecore")]
    [XmlNamespacePrefixAttribute("org.moflon.tgg.runtime")]
    [ModelRepresentationClassAttribute("platform:/plugin/org.moflon.tgg.runtime/model/Runtime.ecore#//PerformRuleResult")]
    public partial class PerformRuleResult : TGGRuleMorphism, IPerformRuleResult, NMF.Models.IModelElement
    {
        
        private static Lazy<NMF.Models.Meta.ITypedElement> _translatedElementsReference = new Lazy<NMF.Models.Meta.ITypedElement>(RetrieveTranslatedElementsReference);
        
        /// <summary>
        /// The backing field for the TranslatedElements property
        /// </summary>
        private ObservableAssociationOrderedSet<NMF.Models.IModelElement> _translatedElements;
        
        private static Lazy<NMF.Models.Meta.ITypedElement> _createdElementsReference = new Lazy<NMF.Models.Meta.ITypedElement>(RetrieveCreatedElementsReference);
        
        /// <summary>
        /// The backing field for the CreatedElements property
        /// </summary>
        private ObservableAssociationOrderedSet<NMF.Models.IModelElement> _createdElements;
        
        private static Lazy<NMF.Models.Meta.ITypedElement> _createdLinkElementsReference = new Lazy<NMF.Models.Meta.ITypedElement>(RetrieveCreatedLinkElementsReference);
        
        /// <summary>
        /// The backing field for the CreatedLinkElements property
        /// </summary>
        private ObservableAssociationOrderedSet<NMF.Models.IModelElement> _createdLinkElements;
        
        private static Lazy<NMF.Models.Meta.ITypedElement> _createdEdgesReference = new Lazy<NMF.Models.Meta.ITypedElement>(RetrieveCreatedEdgesReference);
        
        /// <summary>
        /// The backing field for the CreatedEdges property
        /// </summary>
        private ObservableAssociationOrderedSet<IEMoflonEdge> _createdEdges;
        
        private static Lazy<NMF.Models.Meta.ITypedElement> _translatedEdgesReference = new Lazy<NMF.Models.Meta.ITypedElement>(RetrieveTranslatedEdgesReference);
        
        /// <summary>
        /// The backing field for the TranslatedEdges property
        /// </summary>
        private ObservableAssociationOrderedSet<IEMoflonEdge> _translatedEdges;
        
        private static NMF.Models.Meta.IClass _classInstance;
        
        public PerformRuleResult()
        {
            this._translatedElements = new ObservableAssociationOrderedSet<NMF.Models.IModelElement>();
            this._translatedElements.CollectionChanging += this.TranslatedElementsCollectionChanging;
            this._translatedElements.CollectionChanged += this.TranslatedElementsCollectionChanged;
            this._createdElements = new ObservableAssociationOrderedSet<NMF.Models.IModelElement>();
            this._createdElements.CollectionChanging += this.CreatedElementsCollectionChanging;
            this._createdElements.CollectionChanged += this.CreatedElementsCollectionChanged;
            this._createdLinkElements = new ObservableAssociationOrderedSet<NMF.Models.IModelElement>();
            this._createdLinkElements.CollectionChanging += this.CreatedLinkElementsCollectionChanging;
            this._createdLinkElements.CollectionChanged += this.CreatedLinkElementsCollectionChanged;
            this._createdEdges = new ObservableAssociationOrderedSet<IEMoflonEdge>();
            this._createdEdges.CollectionChanging += this.CreatedEdgesCollectionChanging;
            this._createdEdges.CollectionChanged += this.CreatedEdgesCollectionChanged;
            this._translatedEdges = new ObservableAssociationOrderedSet<IEMoflonEdge>();
            this._translatedEdges.CollectionChanging += this.TranslatedEdgesCollectionChanging;
            this._translatedEdges.CollectionChanged += this.TranslatedEdgesCollectionChanged;
        }
        
        /// <summary>
        /// The translatedElements property
        /// </summary>
        [LowerBoundAttribute(1)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("translatedElements")]
        [XmlAttributeAttribute(true)]
        [ConstantAttribute()]
        public IOrderedSetExpression<NMF.Models.IModelElement> TranslatedElements
        {
            get
            {
                return this._translatedElements;
            }
        }
        
        /// <summary>
        /// The createdElements property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("createdElements")]
        [XmlAttributeAttribute(true)]
        [ConstantAttribute()]
        public IOrderedSetExpression<NMF.Models.IModelElement> CreatedElements
        {
            get
            {
                return this._createdElements;
            }
        }
        
        /// <summary>
        /// The createdLinkElements property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("createdLinkElements")]
        [XmlAttributeAttribute(true)]
        [ConstantAttribute()]
        public IOrderedSetExpression<NMF.Models.IModelElement> CreatedLinkElements
        {
            get
            {
                return this._createdLinkElements;
            }
        }
        
        /// <summary>
        /// The createdEdges property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("createdEdges")]
        [XmlAttributeAttribute(true)]
        [ConstantAttribute()]
        public IOrderedSetExpression<IEMoflonEdge> CreatedEdges
        {
            get
            {
                return this._createdEdges;
            }
        }
        
        /// <summary>
        /// The translatedEdges property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("translatedEdges")]
        [XmlAttributeAttribute(true)]
        [ConstantAttribute()]
        public IOrderedSetExpression<IEMoflonEdge> TranslatedEdges
        {
            get
            {
                return this._translatedEdges;
            }
        }
        
        /// <summary>
        /// Gets the referenced model elements of this model element
        /// </summary>
        public override IEnumerableExpression<NMF.Models.IModelElement> ReferencedElements
        {
            get
            {
                return base.ReferencedElements.Concat(new PerformRuleResultReferencedElementsCollection(this));
            }
        }
        
        /// <summary>
        /// Gets the Class model for this type
        /// </summary>
        public new static NMF.Models.Meta.IClass ClassInstance
        {
            get
            {
                if ((_classInstance == null))
                {
                    _classInstance = ((NMF.Models.Meta.IClass)(MetaRepository.Instance.Resolve("platform:/plugin/org.moflon.tgg.runtime/model/Runtime.ecore#//PerformRuleResult")));
                }
                return _classInstance;
            }
        }
        
        private static NMF.Models.Meta.ITypedElement RetrieveTranslatedElementsReference()
        {
            return ((NMF.Models.Meta.ITypedElement)(((NMF.Models.ModelElement)(NMF.SynchronizationsBenchmark.Runtime.PerformRuleResult.ClassInstance)).Resolve("translatedElements")));
        }
        
        /// <summary>
        /// Forwards CollectionChanging notifications for the TranslatedElements property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void TranslatedElementsCollectionChanging(object sender, NotifyCollectionChangingEventArgs e)
        {
            this.OnCollectionChanging("TranslatedElements", e, _translatedElementsReference);
        }
        
        /// <summary>
        /// Forwards CollectionChanged notifications for the TranslatedElements property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void TranslatedElementsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("TranslatedElements", e, _translatedElementsReference);
        }
        
        private static NMF.Models.Meta.ITypedElement RetrieveCreatedElementsReference()
        {
            return ((NMF.Models.Meta.ITypedElement)(((NMF.Models.ModelElement)(NMF.SynchronizationsBenchmark.Runtime.PerformRuleResult.ClassInstance)).Resolve("createdElements")));
        }
        
        /// <summary>
        /// Forwards CollectionChanging notifications for the CreatedElements property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void CreatedElementsCollectionChanging(object sender, NotifyCollectionChangingEventArgs e)
        {
            this.OnCollectionChanging("CreatedElements", e, _createdElementsReference);
        }
        
        /// <summary>
        /// Forwards CollectionChanged notifications for the CreatedElements property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void CreatedElementsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("CreatedElements", e, _createdElementsReference);
        }
        
        private static NMF.Models.Meta.ITypedElement RetrieveCreatedLinkElementsReference()
        {
            return ((NMF.Models.Meta.ITypedElement)(((NMF.Models.ModelElement)(NMF.SynchronizationsBenchmark.Runtime.PerformRuleResult.ClassInstance)).Resolve("createdLinkElements")));
        }
        
        /// <summary>
        /// Forwards CollectionChanging notifications for the CreatedLinkElements property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void CreatedLinkElementsCollectionChanging(object sender, NotifyCollectionChangingEventArgs e)
        {
            this.OnCollectionChanging("CreatedLinkElements", e, _createdLinkElementsReference);
        }
        
        /// <summary>
        /// Forwards CollectionChanged notifications for the CreatedLinkElements property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void CreatedLinkElementsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("CreatedLinkElements", e, _createdLinkElementsReference);
        }
        
        private static NMF.Models.Meta.ITypedElement RetrieveCreatedEdgesReference()
        {
            return ((NMF.Models.Meta.ITypedElement)(((NMF.Models.ModelElement)(NMF.SynchronizationsBenchmark.Runtime.PerformRuleResult.ClassInstance)).Resolve("createdEdges")));
        }
        
        /// <summary>
        /// Forwards CollectionChanging notifications for the CreatedEdges property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void CreatedEdgesCollectionChanging(object sender, NotifyCollectionChangingEventArgs e)
        {
            this.OnCollectionChanging("CreatedEdges", e, _createdEdgesReference);
        }
        
        /// <summary>
        /// Forwards CollectionChanged notifications for the CreatedEdges property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void CreatedEdgesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("CreatedEdges", e, _createdEdgesReference);
        }
        
        private static NMF.Models.Meta.ITypedElement RetrieveTranslatedEdgesReference()
        {
            return ((NMF.Models.Meta.ITypedElement)(((NMF.Models.ModelElement)(NMF.SynchronizationsBenchmark.Runtime.PerformRuleResult.ClassInstance)).Resolve("translatedEdges")));
        }
        
        /// <summary>
        /// Forwards CollectionChanging notifications for the TranslatedEdges property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void TranslatedEdgesCollectionChanging(object sender, NotifyCollectionChangingEventArgs e)
        {
            this.OnCollectionChanging("TranslatedEdges", e, _translatedEdgesReference);
        }
        
        /// <summary>
        /// Forwards CollectionChanged notifications for the TranslatedEdges property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void TranslatedEdgesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("TranslatedEdges", e, _translatedEdgesReference);
        }
        
        /// <summary>
        /// Gets the Model element collection for the given feature
        /// </summary>
        /// <returns>A non-generic list of elements</returns>
        /// <param name="feature">The requested feature</param>
        protected override System.Collections.IList GetCollectionForFeature(string feature)
        {
            if ((feature == "TRANSLATEDELEMENTS"))
            {
                return this._translatedElements;
            }
            if ((feature == "CREATEDELEMENTS"))
            {
                return this._createdElements;
            }
            if ((feature == "CREATEDLINKELEMENTS"))
            {
                return this._createdLinkElements;
            }
            if ((feature == "CREATEDEDGES"))
            {
                return this._createdEdges;
            }
            if ((feature == "TRANSLATEDEDGES"))
            {
                return this._translatedEdges;
            }
            return base.GetCollectionForFeature(feature);
        }
        
        /// <summary>
        /// Gets the Class for this model element
        /// </summary>
        public override NMF.Models.Meta.IClass GetClass()
        {
            if ((_classInstance == null))
            {
                _classInstance = ((NMF.Models.Meta.IClass)(MetaRepository.Instance.Resolve("platform:/plugin/org.moflon.tgg.runtime/model/Runtime.ecore#//PerformRuleResult")));
            }
            return _classInstance;
        }
        
        /// <summary>
        /// The collection class to to represent the children of the PerformRuleResult class
        /// </summary>
        public class PerformRuleResultReferencedElementsCollection : ReferenceCollection, ICollectionExpression<NMF.Models.IModelElement>, ICollection<NMF.Models.IModelElement>
        {
            
            private PerformRuleResult _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public PerformRuleResultReferencedElementsCollection(PerformRuleResult parent)
            {
                this._parent = parent;
            }
            
            /// <summary>
            /// Gets the amount of elements contained in this collection
            /// </summary>
            public override int Count
            {
                get
                {
                    int count = 0;
                    count = (count + this._parent.TranslatedElements.Count);
                    count = (count + this._parent.CreatedElements.Count);
                    count = (count + this._parent.CreatedLinkElements.Count);
                    count = (count + this._parent.CreatedEdges.Count);
                    count = (count + this._parent.TranslatedEdges.Count);
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.TranslatedElements.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
                this._parent.CreatedElements.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
                this._parent.CreatedLinkElements.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
                this._parent.CreatedEdges.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
                this._parent.TranslatedEdges.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.TranslatedElements.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
                this._parent.CreatedElements.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
                this._parent.CreatedLinkElements.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
                this._parent.CreatedEdges.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
                this._parent.TranslatedEdges.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(NMF.Models.IModelElement item)
            {
                this._parent.TranslatedElements.Add(item);
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.TranslatedElements.Clear();
                this._parent.CreatedElements.Clear();
                this._parent.CreatedLinkElements.Clear();
                this._parent.CreatedEdges.Clear();
                this._parent.TranslatedEdges.Clear();
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(NMF.Models.IModelElement item)
            {
                if (this._parent.TranslatedElements.Contains(item))
                {
                    return true;
                }
                if (this._parent.CreatedElements.Contains(item))
                {
                    return true;
                }
                if (this._parent.CreatedLinkElements.Contains(item))
                {
                    return true;
                }
                if (this._parent.CreatedEdges.Contains(item))
                {
                    return true;
                }
                if (this._parent.TranslatedEdges.Contains(item))
                {
                    return true;
                }
                return false;
            }
            
            /// <summary>
            /// Copies the contents of the collection to the given array starting from the given array index
            /// </summary>
            /// <param name="array">The array in which the elements should be copied</param>
            /// <param name="arrayIndex">The starting index</param>
            public override void CopyTo(NMF.Models.IModelElement[] array, int arrayIndex)
            {
                this._parent.TranslatedElements.CopyTo(array, arrayIndex);
                arrayIndex = (arrayIndex + this._parent.TranslatedElements.Count);
                this._parent.CreatedElements.CopyTo(array, arrayIndex);
                arrayIndex = (arrayIndex + this._parent.CreatedElements.Count);
                this._parent.CreatedLinkElements.CopyTo(array, arrayIndex);
                arrayIndex = (arrayIndex + this._parent.CreatedLinkElements.Count);
                IEnumerator<NMF.Models.IModelElement> createdEdgesEnumerator = this._parent.CreatedEdges.GetEnumerator();
                try
                {
                    for (
                    ; createdEdgesEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = createdEdgesEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    createdEdgesEnumerator.Dispose();
                }
                IEnumerator<NMF.Models.IModelElement> translatedEdgesEnumerator = this._parent.TranslatedEdges.GetEnumerator();
                try
                {
                    for (
                    ; translatedEdgesEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = translatedEdgesEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    translatedEdgesEnumerator.Dispose();
                }
            }
            
            /// <summary>
            /// Removes the given item from the collection
            /// </summary>
            /// <returns>True, if the item was removed, otherwise False</returns>
            /// <param name="item">The item that should be removed</param>
            public override bool Remove(NMF.Models.IModelElement item)
            {
                if (this._parent.TranslatedElements.Remove(item))
                {
                    return true;
                }
                if (this._parent.CreatedElements.Remove(item))
                {
                    return true;
                }
                if (this._parent.CreatedLinkElements.Remove(item))
                {
                    return true;
                }
                IEMoflonEdge eMoflonEdgeItem = item.As<IEMoflonEdge>();
                if (((eMoflonEdgeItem != null) 
                            && this._parent.CreatedEdges.Remove(eMoflonEdgeItem)))
                {
                    return true;
                }
                if (((eMoflonEdgeItem != null) 
                            && this._parent.TranslatedEdges.Remove(eMoflonEdgeItem)))
                {
                    return true;
                }
                return false;
            }
            
            /// <summary>
            /// Gets an enumerator that enumerates the collection
            /// </summary>
            /// <returns>A generic enumerator</returns>
            public override IEnumerator<NMF.Models.IModelElement> GetEnumerator()
            {
                return Enumerable.Empty<NMF.Models.IModelElement>().Concat(this._parent.TranslatedElements).Concat(this._parent.CreatedElements).Concat(this._parent.CreatedLinkElements).Concat(this._parent.CreatedEdges).Concat(this._parent.TranslatedEdges).GetEnumerator();
            }
        }
    }
}

