using System.Reflection;
using Newtonsoft.Json;

namespace EliteAPI.Abstractions.Events;

/// <summary>Provides the framework for building and registering event handlers.</summary>
public interface IEvents
{
    /// <summary>All event types that have been registered.</summary>
    IEnumerable<Type> EventTypes { get; }

    /// <summary>A collection of previous events since the API was started.</summary>
    IReadOnlyCollection<(IEvent @event, EventContext context)> PreviousEvents { get; }

    /// <summary>Adds an event handler that will be invoked when the specified event is raised.</summary>
    /// <param name="handler">The <see cref="EventContextDelegate{TEvent}" /> delegate handler</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    void On<TEvent>(EventContextDelegate<TEvent> handler) where TEvent : IEvent;
    
    /// <summary>Adds an event handler that will be invoked when the specified event is raised.</summary>
    /// <param name="handler">The <see cref="EventDelegate{TEvent}" /> delegate handler</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    void On<TEvent>(EventDelegate<TEvent> handler) where TEvent : IEvent;
    
    /// <summary>Adds an event handler that will be invoked when the specified event is raised.</summary>
    /// <param name="handler">The <see cref="EventContextDelegate{TEvent}" /> delegate handler</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    void On<TEvent>(AsyncEventContextDelegate<TEvent> handler) where TEvent : IEvent;
    
    /// <summary>Adds an event handler that will be invoked when the specified event is raised.</summary>
    /// <param name="handler">The <see cref="EventDelegate{TEvent}" /> delegate handler</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    void On<TEvent>(AsyncEventDelegate<TEvent> handler) where TEvent : IEvent;

    /// <summary>Adds an event handler that will be invoked when the specified event is raised.</summary>
    /// <param name="handler">The <see cref="JsonContextDelegate" /> delegate handler</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    void OnJson<TEvent>(JsonContextDelegate handler) where TEvent : IEvent;
    
    /// <summary>Adds an event handler that will be invoked when the specified event is raised.</summary>
    /// <param name="handler">The <see cref="JsonDelegate" /> delegate handler</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    void OnJson<TEvent>(JsonDelegate handler) where TEvent : IEvent;
    
    /// <summary>Adds an event handler that will be invoked when the specified event is raised.</summary>
    /// <param name="handler">The <see cref="JsonContextDelegate" /> delegate handler</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    void OnJson<TEvent>(AsyncJsonContextDelegate handler) where TEvent : IEvent;
    
    /// <summary>Adds an event handler that will be invoked when the specified event is raised.</summary>
    /// <param name="handler">The <see cref="JsonDelegate" /> delegate handler</param>
    /// <typeparam name="TEvent">The event type</typeparam>
    void OnJson<TEvent>(AsyncJsonDelegate handler) where TEvent : IEvent;

    /// <summary>Adds an event handler that will be called when any event is raised.</summary>
    /// <param name="handler">The <see cref="EventContextDelegate{TEvent}" /> delegate handler</param>
    void OnAny(EventContextDelegate<IEvent> handler);
    
    /// <summary>Adds an event handler that will be called when any event is raised.</summary>
    /// <param name="handler">The <see cref="EventDelegate{TEvent}" /> delegate handler</param>
    void OnAny(EventDelegate<IEvent> handler);
    
    /// <summary>Adds an event handler that will be called when any event is raised.</summary>
    /// <param name="handler">The <see cref="EventContextDelegate{TEvent}" /> delegate handler</param>
    void OnAny(AsyncEventContextDelegate<IEvent> handler);
    
    /// <summary>Adds an event handler that will be called when any event is raised.</summary>
    /// <param name="handler">The <see cref="EventDelegate{TEvent}" /> delegate handler</param>
    void OnAny(AsyncEventDelegate<IEvent> handler);

    /// <summary>Adds an event handler that will be called when any event is raised.</summary>
    /// <param name="handler">The <see cref="JsonContextDelegate" /> delegate handler</param>
    void OnAnyJson(JsonContextDelegate handler);
    
    /// <summary>Adds an event handler that will be called when any event is raised.</summary>
    /// <param name="handler">The <see cref="JsonDelegate" /> delegate handler</param>
    void OnAnyJson(JsonDelegate handler);
    
    /// <summary>Adds an event handler that will be called when any event is raised.</summary>
    /// <param name="handler">The <see cref="JsonContextDelegate" /> delegate handler</param>
    void OnAnyJson(AsyncJsonContextDelegate handler);
    
    /// <summary>Adds an event handler that will be called when any event is raised.</summary>
    /// <param name="handler">The <see cref="JsonDelegate" /> delegate handler</param>
    void OnAnyJson(AsyncJsonDelegate handler);

    /// <summary>Blocks the current thread until the specified event is raised.</summary>
    TEvent WaitFor<TEvent>() where TEvent : IEvent;
    
    /// <summary>Blocks the current thread until the specified event is raised.</summary>
    /// <param name="predicate">The predicate that will be used to determine if the event has been raised</param>
    TEvent WaitFor<TEvent>(Predicate<TEvent> predicate) where TEvent : IEvent;

    /// <summary>Blocks the current thread until the specified event is raised or the timeout has been reached.</summary>
    /// <param name="timeout">The timeout in milliseconds</param>
    TEvent? WaitFor<TEvent>(int timeout) where TEvent : IEvent;
    
    /// <summary>Blocks the current thread until the specified event is raised.</summary>
    /// <param name="predicate">The predicate that will be used to determine if the event has been raised</param>
    /// <param name="timeout">The timeout in milliseconds</param>
    TEvent? WaitFor<TEvent>(Predicate<TEvent> predicate, int timeout) where TEvent : IEvent;

    /// <summary>Blocks the current thread until the specified event is raised or the timeout has been reached.</summary>
    /// <param name="timeout">The timeout</param>
    TEvent? WaitFor<TEvent>(TimeSpan timeout) where TEvent : IEvent;
    
    /// <summary>Blocks the current thread until the specified event is raised or the timeout has been reached.</summary>
    /// <param name="predicate">The predicate that will be used to determine if the event has been raised</param>
    /// <param name="timeout">The timeout</param>
    TEvent? WaitFor<TEvent>(Predicate<TEvent> predicate, TimeSpan timeout) where TEvent : IEvent;

    /// <summary>Blocks the current thread until the specified event is raised or the wait is cancelled.</summary>
    /// <param name="cancellationToken">The cancellation token</param>
    TEvent? WaitFor<TEvent>(CancellationToken cancellationToken) where TEvent : IEvent;
    
    /// <summary>Blocks the current thread until the specified event is raised or the wait is cancelled.</summary>
    /// <param name="predicate">The predicate that will be used to determine if the event has been raised</param>
    /// <param name="cancellationToken">The cancellation token</param>
    TEvent? WaitFor<TEvent>(Predicate<TEvent> predicate, CancellationToken cancellationToken) where TEvent : IEvent;

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
    
    /// <summary>
    /// Checks if the specified event is registered.
    /// </summary>
    /// <typeparam name="TEvent">The event type</typeparam>
    bool IsRegistered<TEvent>() where TEvent : IEvent;

    /// <summary>
    /// Checks if the specified event is registered.
    /// </summary>
    bool IsRegistered(Type? type);
}