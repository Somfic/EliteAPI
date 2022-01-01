﻿using System.Reflection;
using Newtonsoft.Json;

namespace EliteAPI.Abstractions.Events;

/// <summary>Provides the framework for building and registering event handlers.</summary>
public interface IEvents
{
    /// <summary>All event types that have been registered.</summary>
    IEnumerable<Type> EventTypes { get; }

    /// <summary>Adds an event handler that will be invoked when the specified event is raised.</summary>
    /// <param name="handler">The <see cref="EventDelegate{T}" /> delegate handler</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    void On<TEvent>(EventDelegate<TEvent> handler) where TEvent : IEvent;
    
    /// <summary>Adds an event handler that will be invoked when the specified event is raised.</summary>
    /// <param name="handler">The <see cref="RawJsonDelegate" /> delegate handler</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    void On<TEvent>(RawJsonDelegate handler) where TEvent : IEvent;
    
    /// <summary>Adds an event handler that will be invoked when the specified event is raised.</summary>
    /// <param name="handler">The <see cref="JsonDelegate" /> delegate handler</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    void On<TEvent>(JsonDelegate handler) where TEvent : IEvent;

    /// <summary>Adds an event handler that will be called when any event is raised.</summary>
    /// <param name="handler">The <see cref="EventDelegate{T}" /> delegate handler</param>
    void OnAny(EventDelegate<IEvent> handler);
    
    /// <summary>Adds an event handler that will be called when any event is raised.</summary>
    /// <param name="handler">The <see cref="RawJsonDelegate" /> delegate handler</param>
    void OnAny(RawJsonDelegate handler);
    
    /// <summary>Adds an event handler that will be called when any event is raised.</summary>
    /// <param name="handler">The <see cref="JsonDelegate" /> delegate handler</param>
    void OnAny(JsonDelegate handler);

    /// <summary>Invokes the registered event handlers for the specified event.</summary>
    /// <param name="event">The instance of the event</param>
    /// <param name="context">The context of the event</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    void Invoke<TEvent>(TEvent @event, EventContext context) where TEvent : IEvent;

    /// <summary>Converts the JSON to a registered event type and invokes the registered event handlers.</summary>
    /// <param name="json">The event JSON</param>
    /// <param name="context">The context of the event</param>
    void Invoke(string json, EventContext context);

    /// <summary>Discovers and registers all the events in the specified assembly.</summary>
    /// <param name="assembly">The assembly the events are defined in</param>
    void Register(Assembly? assembly);

    /// <summary>Registers the specified event.</summary>
    /// <remarks>If the event is already registered, it will be overwritten.</remarks>
    void Register<TEvent>() where TEvent : IEvent;

    /// <summary>Registers the specified type as an event.</summary>
    /// <remarks>If the event is already registered, it will be overwritten.</remarks>
    /// <exception cref="ArgumentException">Thrown when the type does not inherit from <see cref="IEvent" /></exception>
    void Register(Type? type);

    /// <summary>Registers the default events.</summary>
    void Register();
}