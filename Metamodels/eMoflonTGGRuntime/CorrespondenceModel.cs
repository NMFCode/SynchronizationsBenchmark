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

namespace NMF.SynchronizationsBenchmark.Runtime
{
    
    
    /// <summary>
    /// The default implementation of the CorrespondenceModel class
    /// </summary>
    [XmlNamespaceAttribute("platform:/plugin/org.moflon.tgg.runtime/model/Runtime.ecore")]
    [XmlNamespacePrefixAttribute("org.moflon.tgg.runtime")]
    [ModelRepresentationClassAttribute("platform:/plugin/org.moflon.tgg.runtime/model/Runtime.ecore#//CorrespondenceModel" +
        "/")]
    public class CorrespondenceModel : ModelElement, ICorrespondenceModel, IModelElement
    {
        
        /// <summary>
        /// The backing field for the Correspondences property
        /// </summary>
        private ObservableCompositionOrderedSet<IModelElement> _correspondences;
        
        /// <summary>
        /// The backing field for the Source property
        /// </summary>
        private IModelElement _source;
        
        /// <summary>
        /// The backing field for the Target property
        /// </summary>
        private IModelElement _target;
        
        private static IClass _classInstance;
        
        public CorrespondenceModel()
        {
            this._correspondences = new ObservableCompositionOrderedSet<IModelElement>(this);
            this._correspondences.CollectionChanging += this.CorrespondencesCollectionChanging;
            this._correspondences.CollectionChanged += this.CorrespondencesCollectionChanged;
        }
        
        /// <summary>
        /// The correspondences property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("correspondences")]
        [XmlAttributeAttribute(false)]
        [ContainmentAttribute()]
        [ConstantAttribute()]
        public virtual IOrderedSetExpression<IModelElement> Correspondences
        {
            get
            {
                return this._correspondences;
            }
        }
        
        /// <summary>
        /// The source property
        /// </summary>
        [XmlElementNameAttribute("source")]
        [XmlAttributeAttribute(true)]
        public virtual IModelElement Source
        {
            get
            {
                return this._source;
            }
            set
            {
                if ((this._source != value))
                {
                    IModelElement old = this._source;
                    ValueChangedEventArgs e = new ValueChangedEventArgs(old, value);
                    this.OnSourceChanging(e);
                    this.OnPropertyChanging("Source", e);
                    this._source = value;
                    this.OnSourceChanged(e);
                    this.OnPropertyChanged("Source", e);
                }
            }
        }
        
        /// <summary>
        /// The target property
        /// </summary>
        [XmlElementNameAttribute("target")]
        [XmlAttributeAttribute(true)]
        public virtual IModelElement Target
        {
            get
            {
                return this._target;
            }
            set
            {
                if ((this._target != value))
                {
                    IModelElement old = this._target;
                    ValueChangedEventArgs e = new ValueChangedEventArgs(old, value);
                    this.OnTargetChanging(e);
                    this.OnPropertyChanging("Target", e);
                    this._target = value;
                    this.OnTargetChanged(e);
                    this.OnPropertyChanged("Target", e);
                }
            }
        }
        
        /// <summary>
        /// Gets the child model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> Children
        {
            get
            {
                return base.Children.Concat(new CorrespondenceModelChildrenCollection(this));
            }
        }
        
        /// <summary>
        /// Gets the referenced model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> ReferencedElements
        {
            get
            {
                return base.ReferencedElements.Concat(new CorrespondenceModelReferencedElementsCollection(this));
            }
        }
        
        /// <summary>
        /// Gets the Class model for this type
        /// </summary>
        public new static IClass ClassInstance
        {
            get
            {
                if ((_classInstance == null))
                {
                    _classInstance = ((IClass)(MetaRepository.Instance.Resolve("platform:/plugin/org.moflon.tgg.runtime/model/Runtime.ecore#//CorrespondenceModel" +
                            "/")));
                }
                return _classInstance;
            }
        }
        
        /// <summary>
        /// Gets fired before the Source property changes its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> SourceChanging;
        
        /// <summary>
        /// Gets fired when the Source property changed its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> SourceChanged;
        
        /// <summary>
        /// Gets fired before the Target property changes its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> TargetChanging;
        
        /// <summary>
        /// Gets fired when the Target property changed its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> TargetChanged;
        
        /// <summary>
        /// Forwards CollectionChanging notifications for the Correspondences property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void CorrespondencesCollectionChanging(object sender, NMF.Collections.ObjectModel.NotifyCollectionChangingEventArgs e)
        {
            this.OnCollectionChanging("Correspondences", e);
        }
        
        /// <summary>
        /// Forwards CollectionChanged notifications for the Correspondences property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void CorrespondencesCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("Correspondences", e);
        }
        
        /// <summary>
        /// Raises the SourceChanging event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnSourceChanging(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.SourceChanging;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Raises the SourceChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnSourceChanged(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.SourceChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Handles the event that the Source property must reset
        /// </summary>
        /// <param name="sender">The object that sent this reset request</param>
        /// <param name="eventArgs">The event data for the reset event</param>
        private void OnResetSource(object sender, System.EventArgs eventArgs)
        {
            this.Source = null;
        }
        
        /// <summary>
        /// Raises the TargetChanging event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnTargetChanging(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.TargetChanging;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Raises the TargetChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnTargetChanged(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.TargetChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Handles the event that the Target property must reset
        /// </summary>
        /// <param name="sender">The object that sent this reset request</param>
        /// <param name="eventArgs">The event data for the reset event</param>
        private void OnResetTarget(object sender, System.EventArgs eventArgs)
        {
            this.Target = null;
        }
        
        /// <summary>
        /// Gets the relative URI fragment for the given child model element
        /// </summary>
        /// <returns>A fragment of the relative URI</returns>
        /// <param name="element">The element that should be looked for</param>
        protected override string GetRelativePathForNonIdentifiedChild(IModelElement element)
        {
            int correspondencesIndex = ModelHelper.IndexOfReference(this.Correspondences, element);
            if ((correspondencesIndex != -1))
            {
                return ModelHelper.CreatePath("correspondences", correspondencesIndex);
            }
            return base.GetRelativePathForNonIdentifiedChild(element);
        }
        
        /// <summary>
        /// Resolves the given URI to a child model element
        /// </summary>
        /// <returns>The model element or null if it could not be found</returns>
        /// <param name="reference">The requested reference name</param>
        /// <param name="index">The index of this reference</param>
        protected override IModelElement GetModelElementForReference(string reference, int index)
        {
            if ((reference == "CORRESPONDENCES"))
            {
                if ((index < this.Correspondences.Count))
                {
                    return this.Correspondences[index];
                }
                else
                {
                    return null;
                }
            }
            return base.GetModelElementForReference(reference, index);
        }
        
        /// <summary>
        /// Gets the Model element collection for the given feature
        /// </summary>
        /// <returns>A non-generic list of elements</returns>
        /// <param name="feature">The requested feature</param>
        protected override System.Collections.IList GetCollectionForFeature(string feature)
        {
            if ((feature == "CORRESPONDENCES"))
            {
                return this._correspondences;
            }
            return base.GetCollectionForFeature(feature);
        }
        
        /// <summary>
        /// Sets a value to the given feature
        /// </summary>
        /// <param name="feature">The requested feature</param>
        /// <param name="value">The value that should be set to that feature</param>
        protected override void SetFeature(string feature, object value)
        {
            if ((feature == "SOURCE"))
            {
                this.Source = ((IModelElement)(value));
                return;
            }
            if ((feature == "TARGET"))
            {
                this.Target = ((IModelElement)(value));
                return;
            }
            base.SetFeature(feature, value);
        }
        
        /// <summary>
        /// Gets the property expression for the given attribute
        /// </summary>
        /// <returns>An incremental property expression</returns>
        /// <param name="attribute">The requested attribute in upper case</param>
        protected override NMF.Expressions.INotifyExpression<object> GetExpressionForAttribute(string attribute)
        {
            if ((attribute == "Source"))
            {
                return new SourceProxy(this);
            }
            if ((attribute == "Target"))
            {
                return new TargetProxy(this);
            }
            return base.GetExpressionForAttribute(attribute);
        }
        
        /// <summary>
        /// Gets the property expression for the given reference
        /// </summary>
        /// <returns>An incremental property expression</returns>
        /// <param name="reference">The requested reference in upper case</param>
        protected override NMF.Expressions.INotifyExpression<NMF.Models.IModelElement> GetExpressionForReference(string reference)
        {
            if ((reference == "Source"))
            {
                return new SourceProxy(this);
            }
            if ((reference == "Target"))
            {
                return new TargetProxy(this);
            }
            return base.GetExpressionForReference(reference);
        }
        
        /// <summary>
        /// Gets the Class for this model element
        /// </summary>
        public override IClass GetClass()
        {
            if ((_classInstance == null))
            {
                _classInstance = ((IClass)(MetaRepository.Instance.Resolve("platform:/plugin/org.moflon.tgg.runtime/model/Runtime.ecore#//CorrespondenceModel" +
                        "/")));
            }
            return _classInstance;
        }
        
        /// <summary>
        /// The collection class to to represent the children of the CorrespondenceModel class
        /// </summary>
        public class CorrespondenceModelChildrenCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private CorrespondenceModel _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public CorrespondenceModelChildrenCollection(CorrespondenceModel parent)
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
                    count = (count + this._parent.Correspondences.Count);
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.Correspondences.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.Correspondences.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                this._parent.Correspondences.Add(item);
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.Correspondences.Clear();
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if (this._parent.Correspondences.Contains(item))
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
            public override void CopyTo(IModelElement[] array, int arrayIndex)
            {
                this._parent.Correspondences.CopyTo(array, arrayIndex);
                arrayIndex = (arrayIndex + this._parent.Correspondences.Count);
            }
            
            /// <summary>
            /// Removes the given item from the collection
            /// </summary>
            /// <returns>True, if the item was removed, otherwise False</returns>
            /// <param name="item">The item that should be removed</param>
            public override bool Remove(IModelElement item)
            {
                if (this._parent.Correspondences.Remove(item))
                {
                    return true;
                }
                return false;
            }
            
            /// <summary>
            /// Gets an enumerator that enumerates the collection
            /// </summary>
            /// <returns>A generic enumerator</returns>
            public override IEnumerator<IModelElement> GetEnumerator()
            {
                return Enumerable.Empty<IModelElement>().Concat(this._parent.Correspondences).GetEnumerator();
            }
        }
        
        /// <summary>
        /// The collection class to to represent the children of the CorrespondenceModel class
        /// </summary>
        public class CorrespondenceModelReferencedElementsCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private CorrespondenceModel _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public CorrespondenceModelReferencedElementsCollection(CorrespondenceModel parent)
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
                    count = (count + this._parent.Correspondences.Count);
                    if ((this._parent.Source != null))
                    {
                        count = (count + 1);
                    }
                    if ((this._parent.Target != null))
                    {
                        count = (count + 1);
                    }
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.Correspondences.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
                this._parent.SourceChanged += this.PropagateValueChanges;
                this._parent.TargetChanged += this.PropagateValueChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.Correspondences.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
                this._parent.SourceChanged -= this.PropagateValueChanges;
                this._parent.TargetChanged -= this.PropagateValueChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                this._parent.Correspondences.Add(item);
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.Correspondences.Clear();
                this._parent.Source = null;
                this._parent.Target = null;
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if (this._parent.Correspondences.Contains(item))
                {
                    return true;
                }
                if ((item == this._parent.Source))
                {
                    return true;
                }
                if ((item == this._parent.Target))
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
            public override void CopyTo(IModelElement[] array, int arrayIndex)
            {
                this._parent.Correspondences.CopyTo(array, arrayIndex);
                arrayIndex = (arrayIndex + this._parent.Correspondences.Count);
                if ((this._parent.Source != null))
                {
                    array[arrayIndex] = this._parent.Source;
                    arrayIndex = (arrayIndex + 1);
                }
                if ((this._parent.Target != null))
                {
                    array[arrayIndex] = this._parent.Target;
                    arrayIndex = (arrayIndex + 1);
                }
            }
            
            /// <summary>
            /// Removes the given item from the collection
            /// </summary>
            /// <returns>True, if the item was removed, otherwise False</returns>
            /// <param name="item">The item that should be removed</param>
            public override bool Remove(IModelElement item)
            {
                if (this._parent.Correspondences.Remove(item))
                {
                    return true;
                }
                if ((this._parent.Source == item))
                {
                    this._parent.Source = null;
                    return true;
                }
                if ((this._parent.Target == item))
                {
                    this._parent.Target = null;
                    return true;
                }
                return false;
            }
            
            /// <summary>
            /// Gets an enumerator that enumerates the collection
            /// </summary>
            /// <returns>A generic enumerator</returns>
            public override IEnumerator<IModelElement> GetEnumerator()
            {
                return Enumerable.Empty<IModelElement>().Concat(this._parent.Correspondences).Concat(this._parent.Source).Concat(this._parent.Target).GetEnumerator();
            }
        }
        
        /// <summary>
        /// Represents a proxy to represent an incremental access to the source property
        /// </summary>
        private sealed class SourceProxy : ModelPropertyChange<ICorrespondenceModel, IModelElement>
        {
            
            /// <summary>
            /// Creates a new observable property access proxy
            /// </summary>
            /// <param name="modelElement">The model instance element for which to create the property access proxy</param>
            public SourceProxy(ICorrespondenceModel modelElement) : 
                    base(modelElement)
            {
            }
            
            /// <summary>
            /// Gets or sets the value of this expression
            /// </summary>
            public override IModelElement Value
            {
                get
                {
                    return this.ModelElement.Source;
                }
                set
                {
                    this.ModelElement.Source = value;
                }
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be subscribed to the property change event</param>
            protected override void RegisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.SourceChanged += handler;
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be unsubscribed from the property change event</param>
            protected override void UnregisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.SourceChanged -= handler;
            }
        }
        
        /// <summary>
        /// Represents a proxy to represent an incremental access to the target property
        /// </summary>
        private sealed class TargetProxy : ModelPropertyChange<ICorrespondenceModel, IModelElement>
        {
            
            /// <summary>
            /// Creates a new observable property access proxy
            /// </summary>
            /// <param name="modelElement">The model instance element for which to create the property access proxy</param>
            public TargetProxy(ICorrespondenceModel modelElement) : 
                    base(modelElement)
            {
            }
            
            /// <summary>
            /// Gets or sets the value of this expression
            /// </summary>
            public override IModelElement Value
            {
                get
                {
                    return this.ModelElement.Target;
                }
                set
                {
                    this.ModelElement.Target = value;
                }
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be subscribed to the property change event</param>
            protected override void RegisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.TargetChanged += handler;
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be unsubscribed from the property change event</param>
            protected override void UnregisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.TargetChanged -= handler;
            }
        }
    }
}

