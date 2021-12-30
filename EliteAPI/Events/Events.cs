using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EliteAPI.Abstractions.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EliteAPI.Events;

/// <inheritdoc />
public class Events : IEvents
{
    private readonly ILogger<Events>? _log;
    private readonly IServiceProvider _services;
    private readonly List<Delegate> _anyEventHandlers = new();
    private readonly List<JsonConverter> _converters = new();

    private readonly IDictionary<Type, IList<Delegate>> _eventHandlers = new Dictionary<Type, IList<Delegate>>();

    public Events(ILogger<Events>? log, IServiceProvider services)
    {
        _log = log;
        _services = services;
    }

    public IEnumerable<Type> EventTypes => _eventHandlers.Keys;

    public IEnumerable<JsonConverter> Converters => _converters.AsReadOnly();

    /// <inheritdoc />
    public void On<TEvent>(EventDelegate<TEvent> handler) where TEvent : IEvent
    {
        var eventType = typeof(TEvent);

        if (!_eventHandlers.ContainsKey(eventType))
        {
            _log?.LogDebug("Event {Event} is not registered, registering now", eventType.FullName);
            Register<TEvent>();
        }

        if (_eventHandlers.TryGetValue(eventType, out var handlers))
            handlers.Add(handler);
        else
            _eventHandlers.Add(eventType, new List<Delegate> {handler});
    }

    /// <inheritdoc />
    public void OnAny(EventDelegate<IEvent> handler)
    {
        _anyEventHandlers.Add(handler);
    }

    /// <inheritdoc />
    public void Invoke<TEvent>(TEvent argument) where TEvent : IEvent
    {
        var eventType = typeof(TEvent);

        if (!_eventHandlers.ContainsKey(eventType))
        {
            _log?.LogDebug("Event {Event} is not registered, registering now", eventType.FullName);
            Register<TEvent>();
        }

        var handlers = _eventHandlers[eventType];

        foreach (var handler in handlers)
        {
            _log?.LogTrace("Invoking handler {Handler} for event {Event}", handler.Method.Name, eventType.FullName);
            handler.DynamicInvoke(argument);
        }

        foreach (var handler in _anyEventHandlers)
        {
            _log?.LogTrace("Invoking handler {Handler} for event {Event} (any)", handler.Method.Name,
                eventType.FullName);
            handler.DynamicInvoke(argument);
        }
    }

    /// <inheritdoc />
    public void RegisterConverter<TConverter>() where TConverter : JsonConverter
    {
        var converter = ActivatorUtilities.CreateInstance<TConverter>(_services);
        _converters.Add(converter);
    }

    /// <inheritdoc />
    public void Register(Assembly? assembly)
    {
        if (assembly == null)
        {
            _log?.LogWarning("The specified assembly is null. No events will be registered");
            return;
        }

        var name = assembly.GetName();

        _log?.LogDebug("Registering events from {Assembly} v{Version}", name.Name, name.Version);

        var eventTypes = assembly.GetTypes().Where(IsValidEventType).ToArray();

        foreach (var type in eventTypes) AddEvent(type);

        _log?.LogDebug("Registered {Count} events from {Assembly} v{Version}", eventTypes.Length, name.Name,
            name.Version);
    }

    /// <inheritdoc />
    public void Register<TEvent>() where TEvent : IEvent
    {
        Register(typeof(TEvent));
    }

    /// <inheritdoc />
    public void Register(Type? type)
    {
        if (type == null)
            return;

        if (!IsValidEventType(type))
            throw new ArgumentException($"{type.Name} is not a valid event type");

        AddEvent(type);
    }

    /// <inheritdoc />
    public void Register()
    {
        try
        {
            Register(Assembly.Load("EliteAPI.Events"));
        }
        catch (Exception ex)
        {
            _log?.LogWarning(ex, "Could not find the default events implementation");
        }
    }

    private void AddEvent(Type type)
    {
        try
        {
            if (_eventHandlers.Any(x => x.Key.Name == type.Name))
            {
                var oldEvent = _eventHandlers.Keys.First(x => x.Name == type.Name);

                // Return if already registered
                if (oldEvent == type)
                {
                    _log?.LogTrace("Event {Event} is already registered, skipping", type.FullName);
                    return;
                }

                _log?.LogTrace("Overwriting event {OldEvent} with {Event}", oldEvent.FullName, type.FullName);

                _eventHandlers.Remove(oldEvent);
                _eventHandlers.Add(type, new List<Delegate>());
            }
            else
            {
                _log?.LogTrace("Registering event {Event}", type.FullName);
                _eventHandlers.Add(type, new List<Delegate>());
            }
        }
        catch (Exception ex)
        {
            _log?.LogWarning(ex, "Could not register event {Event}", type.FullName);
            throw;
        }
    }

    private static bool IsValidEventType(Type type)
    {
        return type.GetInterfaces().Contains(typeof(IEvent));
    }
}