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
    /// The default implementation of the Transition class
    /// </summary>
    [XmlNamespaceAttribute("platform:/plugin/FiniteStateMachines/model/FiniteStateMachines.ecore")]
    [XmlNamespacePrefixAttribute("fsm")]
    [ModelRepresentationClassAttribute("platform:/plugin/FiniteStateMachines/model/FiniteStateMachines.ecore#//Transition" +
        "/")]
    public class Transition : ModelElement, ITransition, IModelElement
    {
        
        /// <summary>
        /// The backing field for the Input property
        /// </summary>
        private string _input;
        
        /// <summary>
        /// The backing field for the StartState property
        /// </summary>
        private IState _startState;
        
        /// <summary>
        /// The backing field for the EndState property
        /// </summary>
        private IState _endState;
        
        private static IClass _classInstance;
        
        /// <summary>
        /// The input property
        /// </summary>
        [XmlElementNameAttribute("input")]
        [XmlAttributeAttribute(true)]
        public virtual string Input
        {
            get
            {
                return this._input;
            }
            set
            {
                if ((this._input != value))
                {
                    string old = this._input;
                    ValueChangedEventArgs e = new ValueChangedEventArgs(old, value);
                    this.OnInputChanging(e);
                    this.OnPropertyChanging("Input", e);
                    this._input = value;
                    this.OnInputChanged(e);
                    this.OnPropertyChanged("Input", e);
                }
            }
        }
        
        /// <summary>
        /// The startState property
        /// </summary>
        [XmlElementNameAttribute("startState")]
        [XmlAttributeAttribute(true)]
        [XmlOppositeAttribute("transitions")]
        public virtual IState StartState
        {
            get
            {
                return this._startState;
            }
            set
            {
                if ((this._startState != value))
                {
                    IState old = this._startState;
                    ValueChangedEventArgs e = new ValueChangedEventArgs(old, value);
                    this.OnStartStateChanging(e);
                    this.OnPropertyChanging("StartState", e);
                    this._startState = value;
                    if ((old != null))
                    {
                        old.Transitions.Remove(this);
                        old.Deleted -= this.OnResetStartState;
                    }
                    if ((value != null))
                    {
                        value.Transitions.Add(this);
                        value.Deleted += this.OnResetStartState;
                    }
                    this.OnStartStateChanged(e);
                    this.OnPropertyChanged("StartState", e);
                }
            }
        }
        
        /// <summary>
        /// The endState property
        /// </summary>
        [XmlElementNameAttribute("endState")]
        [XmlAttributeAttribute(true)]
        public virtual IState EndState
        {
            get
            {
                return this._endState;
            }
            set
            {
                if ((this._endState != value))
                {
                    IState old = this._endState;
                    ValueChangedEventArgs e = new ValueChangedEventArgs(old, value);
                    this.OnEndStateChanging(e);
                    this.OnPropertyChanging("EndState", e);
                    this._endState = value;
                    if ((old != null))
                    {
                        old.Deleted -= this.OnResetEndState;
                    }
                    if ((value != null))
                    {
                        value.Deleted += this.OnResetEndState;
                    }
                    this.OnEndStateChanged(e);
                    this.OnPropertyChanged("EndState", e);
                }
            }
        }

        protected override Uri CreateUriWithFragment(string fragment, bool absolute)
        {
            return base.CreateUriWithFragment(fragment, absolute);
        }

        /// <summary>
        /// Gets the referenced model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> ReferencedElements
        {
            get
            {
                return base.ReferencedElements.Concat(new TransitionReferencedElementsCollection(this));
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
                    _classInstance = ((IClass)(MetaRepository.Instance.Resolve("platform:/plugin/FiniteStateMachines/model/FiniteStateMachines.ecore#//Transition" +
                            "/")));
                }
                return _classInstance;
            }
        }
        
        /// <summary>
        /// Gets fired before the Input property changes its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> InputChanging;
        
        /// <summary>
        /// Gets fired when the Input property changed its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> InputChanged;
        
        /// <summary>
        /// Gets fired before the StartState property changes its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> StartStateChanging;
        
        /// <summary>
        /// Gets fired when the StartState property changed its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> StartStateChanged;
        
        /// <summary>
        /// Gets fired before the EndState property changes its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> EndStateChanging;
        
        /// <summary>
        /// Gets fired when the EndState property changed its value
        /// </summary>
        public event System.EventHandler<ValueChangedEventArgs> EndStateChanged;
        
        /// <summary>
        /// Raises the InputChanging event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnInputChanging(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.InputChanging;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Raises the InputChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnInputChanged(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.InputChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Raises the StartStateChanging event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnStartStateChanging(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.StartStateChanging;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Raises the StartStateChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnStartStateChanged(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.StartStateChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Handles the event that the StartState property must reset
        /// </summary>
        /// <param name="sender">The object that sent this reset request</param>
        /// <param name="eventArgs">The event data for the reset event</param>
        private void OnResetStartState(object sender, System.EventArgs eventArgs)
        {
            this.StartState = null;
        }
        
        /// <summary>
        /// Raises the EndStateChanging event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnEndStateChanging(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.EndStateChanging;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Raises the EndStateChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnEndStateChanged(ValueChangedEventArgs eventArgs)
        {
            System.EventHandler<ValueChangedEventArgs> handler = this.EndStateChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Handles the event that the EndState property must reset
        /// </summary>
        /// <param name="sender">The object that sent this reset request</param>
        /// <param name="eventArgs">The event data for the reset event</param>
        private void OnResetEndState(object sender, System.EventArgs eventArgs)
        {
            this.EndState = null;
        }
        
        /// <summary>
        /// Resolves the given attribute name
        /// </summary>
        /// <returns>The attribute value or null if it could not be found</returns>
        /// <param name="attribute">The requested attribute name</param>
        /// <param name="index">The index of this attribute</param>
        protected override object GetAttributeValue(string attribute, int index)
        {
            if ((attribute == "INPUT"))
            {
                return this.Input;
            }
            return base.GetAttributeValue(attribute, index);
        }
        
        /// <summary>
        /// Sets a value to the given feature
        /// </summary>
        /// <param name="feature">The requested feature</param>
        /// <param name="value">The value that should be set to that feature</param>
        protected override void SetFeature(string feature, object value)
        {
            if ((feature == "STARTSTATE"))
            {
                this.StartState = ((IState)(value));
                return;
            }
            if ((feature == "ENDSTATE"))
            {
                this.EndState = ((IState)(value));
                return;
            }
            if ((feature == "INPUT"))
            {
                this.Input = ((string)(value));
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
            if ((attribute == "StartState"))
            {
                return new StartStateProxy(this);
            }
            if ((attribute == "EndState"))
            {
                return new EndStateProxy(this);
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
            if ((reference == "StartState"))
            {
                return new StartStateProxy(this);
            }
            if ((reference == "EndState"))
            {
                return new EndStateProxy(this);
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
                _classInstance = ((IClass)(MetaRepository.Instance.Resolve("platform:/plugin/FiniteStateMachines/model/FiniteStateMachines.ecore#//Transition" +
                        "/")));
            }
            return _classInstance;
        }
        
        /// <summary>
        /// The collection class to to represent the children of the Transition class
        /// </summary>
        public class TransitionReferencedElementsCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private Transition _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public TransitionReferencedElementsCollection(Transition parent)
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
                    if ((this._parent.StartState != null))
                    {
                        count = (count + 1);
                    }
                    if ((this._parent.EndState != null))
                    {
                        count = (count + 1);
                    }
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.StartStateChanged += this.PropagateValueChanges;
                this._parent.EndStateChanged += this.PropagateValueChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.StartStateChanged -= this.PropagateValueChanges;
                this._parent.EndStateChanged -= this.PropagateValueChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                if ((this._parent.StartState == null))
                {
                    IState startStateCasted = item.As<IState>();
                    if ((startStateCasted != null))
                    {
                        this._parent.StartState = startStateCasted;
                        return;
                    }
                }
                if ((this._parent.EndState == null))
                {
                    IState endStateCasted = item.As<IState>();
                    if ((endStateCasted != null))
                    {
                        this._parent.EndState = endStateCasted;
                        return;
                    }
                }
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.StartState = null;
                this._parent.EndState = null;
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if ((item == this._parent.StartState))
                {
                    return true;
                }
                if ((item == this._parent.EndState))
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
                if ((this._parent.StartState != null))
                {
                    array[arrayIndex] = this._parent.StartState;
                    arrayIndex = (arrayIndex + 1);
                }
                if ((this._parent.EndState != null))
                {
                    array[arrayIndex] = this._parent.EndState;
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
                if ((this._parent.StartState == item))
                {
                    this._parent.StartState = null;
                    return true;
                }
                if ((this._parent.EndState == item))
                {
                    this._parent.EndState = null;
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
                return Enumerable.Empty<IModelElement>().Concat(this._parent.StartState).Concat(this._parent.EndState).GetEnumerator();
            }
        }
        
        /// <summary>
        /// Represents a proxy to represent an incremental access to the input property
        /// </summary>
        private sealed class InputProxy : ModelPropertyChange<ITransition, string>
        {
            
            /// <summary>
            /// Creates a new observable property access proxy
            /// </summary>
            /// <param name="modelElement">The model instance element for which to create the property access proxy</param>
            public InputProxy(ITransition modelElement) : 
                    base(modelElement)
            {
            }
            
            /// <summary>
            /// Gets or sets the value of this expression
            /// </summary>
            public override string Value
            {
                get
                {
                    return this.ModelElement.Input;
                }
                set
                {
                    this.ModelElement.Input = value;
                }
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be subscribed to the property change event</param>
            protected override void RegisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.InputChanged += handler;
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be unsubscribed from the property change event</param>
            protected override void UnregisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.InputChanged -= handler;
            }
        }
        
        /// <summary>
        /// Represents a proxy to represent an incremental access to the startState property
        /// </summary>
        private sealed class StartStateProxy : ModelPropertyChange<ITransition, IState>
        {
            
            /// <summary>
            /// Creates a new observable property access proxy
            /// </summary>
            /// <param name="modelElement">The model instance element for which to create the property access proxy</param>
            public StartStateProxy(ITransition modelElement) : 
                    base(modelElement)
            {
            }
            
            /// <summary>
            /// Gets or sets the value of this expression
            /// </summary>
            public override IState Value
            {
                get
                {
                    return this.ModelElement.StartState;
                }
                set
                {
                    this.ModelElement.StartState = value;
                }
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be subscribed to the property change event</param>
            protected override void RegisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.StartStateChanged += handler;
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be unsubscribed from the property change event</param>
            protected override void UnregisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.StartStateChanged -= handler;
            }
        }
        
        /// <summary>
        /// Represents a proxy to represent an incremental access to the endState property
        /// </summary>
        private sealed class EndStateProxy : ModelPropertyChange<ITransition, IState>
        {
            
            /// <summary>
            /// Creates a new observable property access proxy
            /// </summary>
            /// <param name="modelElement">The model instance element for which to create the property access proxy</param>
            public EndStateProxy(ITransition modelElement) : 
                    base(modelElement)
            {
            }
            
            /// <summary>
            /// Gets or sets the value of this expression
            /// </summary>
            public override IState Value
            {
                get
                {
                    return this.ModelElement.EndState;
                }
                set
                {
                    this.ModelElement.EndState = value;
                }
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be subscribed to the property change event</param>
            protected override void RegisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.EndStateChanged += handler;
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be unsubscribed from the property change event</param>
            protected override void UnregisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.EndStateChanged -= handler;
            }
        }
    }
}

