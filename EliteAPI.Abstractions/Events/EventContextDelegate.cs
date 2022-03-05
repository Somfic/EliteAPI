using Newtonsoft.Json.Linq;

namespace EliteAPI.Abstractions.Events;

/// <summary>
/// Handles an <see cref="IEvent"/> event.
/// </summary>
/// <typeparam name="TEvent">The type of <see cref="IEvent"/> that is being handled</typeparam>
public delegate void EventContextDelegate<in TEvent>(TEvent @event, EventContext context) where TEvent : IEvent;

/// <summary>
/// Handles an <see cref="IEvent"/> event.
/// </summary>
/// <typeparam name="TEvent">The type of <see cref="IEvent"/> that is being handled</typeparam>
public delegate void EventDelegate<in TEvent>(TEvent @event) where TEvent : IEvent;


/// <summary>
/// Handles a JSON event.
/// </summary>
public delegate void JsonContextDelegate(string json, EventContext context);

/// <summary>
/// Handles a JSON event.
/// </summary>
public delegate void JsonDelegate(string json);