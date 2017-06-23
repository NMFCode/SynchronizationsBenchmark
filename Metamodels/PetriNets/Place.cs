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

namespace NMF.SynchronizationsBenchmark.PetriNets
{
    
    
    /// <summary>
    /// The default implementation of the Place class
    /// </summary>
    [XmlIdentifierAttribute("id")]
    [XmlNamespaceAttribute("platform:/plugin/PetriNets/model/PetriNets.ecore")]
    [XmlNamespacePrefixAttribute("pn")]
    [ModelRepresentationClassAttribute("platform:/plugin/PetriNets/model/PetriNets.ecore#//Place")]
    [DebuggerDisplayAttribute("Place {Id}")]
    public partial class Place : ModelElement, IPlace, IModelElement
    {
        
        /// <summary>
        /// The backing field for the Id property
        /// </summary>
        private string _id = "";
        
        private static Lazy<ITypedElement> _idAttribute = new Lazy<ITypedElement>(RetrieveIdAttribute);
        
        private static Lazy<ITypedElement> _incomingReference = new Lazy<ITypedElement>(RetrieveIncomingReference);
        
        /// <summary>
        /// The backing field for the Incoming property
        /// </summary>
        private PlaceIncomingCollection _incoming;
        
        private static Lazy<ITypedElement> _outgoingReference = new Lazy<ITypedElement>(RetrieveOutgoingReference);
        
        /// <summary>
        /// The backing field for the Outgoing property
        /// </summary>
        private PlaceOutgoingCollection _outgoing;
        
        private static IClass _classInstance;
        
        public Place()
        {
            this._incoming = new PlaceIncomingCollection(this);
            this._incoming.CollectionChanging += this.IncomingCollectionChanging;
            this._incoming.CollectionChanged += this.IncomingCollectionChanged;
            this._outgoing = new PlaceOutgoingCollection(this);
            this._outgoing.CollectionChanging += this.OutgoingCollectionChanging;
            this._outgoing.CollectionChanged += this.OutgoingCollectionChanged;
        }
        
        /// <summary>
        /// The id property
        /// </summary>
        [DefaultValueAttribute("")]
        [XmlElementNameAttribute("id")]
        [IdAttribute()]
        [XmlAttributeAttribute(true)]
        public string Id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    string old = this._id;
                    ValueChangedEventArgs e = new ValueChangedEventArgs(old, value);
                    this.OnIdChanging(e);
                    this.OnPropertyChanging("Id", e, _idAttribute);
                    this._id = value;
                    this.OnIdChanged(e);
                    this.OnPropertyChanged("Id", e, _idAttribute);
                }
            }
        }
        
        /// <summary>
        /// The incoming property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("incoming")]
        [XmlAttributeAttribute(true)]
        [XmlOppositeAttribute("to")]
        [ConstantAttribute()]
        public IOrderedSetExpression<ITransition> Incoming
        {
            get
            {
                return this._incoming;
            }
        }
        
        /// <summary>
        /// The outgoing property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("outgoing")]
        [XmlAttributeAttribute(true)]
        [XmlOppositeAttribute("from")]
        [ConstantAttribute()]
        public IOrderedSetExpression<ITransition> Outgoing
        {
            get
            {
                return this._outgoing;
            }
        }
        
        /// <summary>
        /// Gets the referenced model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> ReferencedElements
        {
            get
            {
                return base.ReferencedElements.Concat(new PlaceReferencedElementsCollection(this));
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
                    _classInstance = ((IClass)(MetaRepository.Instance.Resolve("platform:/plugin/PetriNets/model/PetriNets.ecore#//Place")));
                }
                return _classInstance;
            }
        }
        
        /// <summary>
        /// Gets a value indicating whether the current model element can be identified by an attribute value
        /// </summary>
        public override bool IsIdentified
        {
            get
            {
                return true;
            }
        }
        
        /// <summary>
        /// Gets fired before the Id property changes its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> IdChanging;
        
        /// <summary>
        /// Gets fired when the Id property changed its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> IdChanged;
        
        private static ITypedElement RetrieveIdAttribute()
        {
            return ((ITypedElement)(((ModelElement)(NMF.SynchronizationsBenchmark.PetriNets.Place.ClassInstance)).Resolve("id")));
        }
        
        /// <summary>
        /// Raises the IdChanging event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnIdChanging(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.IdChanging;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Raises the IdChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnIdChanged(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.IdChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        private static ITypedElement RetrieveIncomingReference()
        {
            return ((ITypedElement)(((ModelElement)(NMF.SynchronizationsBenchmark.PetriNets.Place.ClassInstance)).Resolve("incoming")));
        }
        
        /// <summary>
        /// Forwards CollectionChanging notifications for the Incoming property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void IncomingCollectionChanging(object sender, NotifyCollectionChangingEventArgs e)
        {
            this.OnCollectionChanging("Incoming", e, _incomingReference);
        }
        
        /// <summary>
        /// Forwards CollectionChanged notifications for the Incoming property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void IncomingCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("Incoming", e, _incomingReference);
        }
        
        private static ITypedElement RetrieveOutgoingReference()
        {
            return ((ITypedElement)(((ModelElement)(NMF.SynchronizationsBenchmark.PetriNets.Place.ClassInstance)).Resolve("outgoing")));
        }
        
        /// <summary>
        /// Forwards CollectionChanging notifications for the Outgoing property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void OutgoingCollectionChanging(object sender, NotifyCollectionChangingEventArgs e)
        {
            this.OnCollectionChanging("Outgoing", e, _outgoingReference);
        }
        
        /// <summary>
        /// Forwards CollectionChanged notifications for the Outgoing property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void OutgoingCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("Outgoing", e, _outgoingReference);
        }
        
        /// <summary>
        /// Resolves the given attribute name
        /// </summary>
        /// <returns>The attribute value or null if it could not be found</returns>
        /// <param name="attribute">The requested attribute name</param>
        /// <param name="index">The index of this attribute</param>
        protected override object GetAttributeValue(string attribute, int index)
        {
            if ((attribute == "ID"))
            {
                return this.Id;
            }
            return base.GetAttributeValue(attribute, index);
        }
        
        /// <summary>
        /// Gets the Model element collection for the given feature
        /// </summary>
        /// <returns>A non-generic list of elements</returns>
        /// <param name="feature">The requested feature</param>
        protected override System.Collections.IList GetCollectionForFeature(string feature)
        {
            if ((feature == "INCOMING"))
            {
                return this._incoming;
            }
            if ((feature == "OUTGOING"))
            {
                return this._outgoing;
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
            if ((feature == "ID"))
            {
                this.Id = ((string)(value));
                return;
            }
            base.SetFeature(feature, value);
        }
        
        /// <summary>
        /// Gets the Class for this model element
        /// </summary>
        public override IClass GetClass()
        {
            if ((_classInstance == null))
            {
                _classInstance = ((IClass)(MetaRepository.Instance.Resolve("platform:/plugin/PetriNets/model/PetriNets.ecore#//Place")));
            }
            return _classInstance;
        }
        
        /// <summary>
        /// Gets the identifier string for this model element
        /// </summary>
        /// <returns>The identifier string</returns>
        public override string ToIdentifierString()
        {
            if ((this.Id == null))
            {
                return null;
            }
            return this.Id.ToString();
        }
        
        /// <summary>
        /// The collection class to to represent the children of the Place class
        /// </summary>
        public class PlaceReferencedElementsCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private Place _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public PlaceReferencedElementsCollection(Place parent)
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
                    count = (count + this._parent.Incoming.Count);
                    count = (count + this._parent.Outgoing.Count);
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.Incoming.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
                this._parent.Outgoing.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.Incoming.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
                this._parent.Outgoing.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                ITransition incomingCasted = item.As<ITransition>();
                if ((incomingCasted != null))
                {
                    this._parent.Incoming.Add(incomingCasted);
                }
                ITransition outgoingCasted = item.As<ITransition>();
                if ((outgoingCasted != null))
                {
                    this._parent.Outgoing.Add(outgoingCasted);
                }
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.Incoming.Clear();
                this._parent.Outgoing.Clear();
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if (this._parent.Incoming.Contains(item))
                {
                    return true;
                }
                if (this._parent.Outgoing.Contains(item))
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
                IEnumerator<IModelElement> incomingEnumerator = this._parent.Incoming.GetEnumerator();
                try
                {
                    for (
                    ; incomingEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = incomingEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    incomingEnumerator.Dispose();
                }
                IEnumerator<IModelElement> outgoingEnumerator = this._parent.Outgoing.GetEnumerator();
                try
                {
                    for (
                    ; outgoingEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = outgoingEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    outgoingEnumerator.Dispose();
                }
            }
            
            /// <summary>
            /// Removes the given item from the collection
            /// </summary>
            /// <returns>True, if the item was removed, otherwise False</returns>
            /// <param name="item">The item that should be removed</param>
            public override bool Remove(IModelElement item)
            {
                ITransition transitionItem = item.As<ITransition>();
                if (((transitionItem != null) 
                            && this._parent.Incoming.Remove(transitionItem)))
                {
                    return true;
                }
                if (((transitionItem != null) 
                            && this._parent.Outgoing.Remove(transitionItem)))
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
                return Enumerable.Empty<IModelElement>().Concat(this._parent.Incoming).Concat(this._parent.Outgoing).GetEnumerator();
            }
        }
        
        /// <summary>
        /// Represents a proxy to represent an incremental access to the id property
        /// </summary>
        private sealed class IdProxy : ModelPropertyChange<IPlace, string>
        {
            
            /// <summary>
            /// Creates a new observable property access proxy
            /// </summary>
            /// <param name="modelElement">The model instance element for which to create the property access proxy</param>
            public IdProxy(IPlace modelElement) : 
                    base(modelElement, "id")
            {
            }
            
            /// <summary>
            /// Gets or sets the value of this expression
            /// </summary>
            public override string Value
            {
                get
                {
                    return this.ModelElement.Id;
                }
                set
                {
                    this.ModelElement.Id = value;
                }
            }
        }
    }
}

