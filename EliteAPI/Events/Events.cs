using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EliteAPI.Abstractions.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Events;

/// <inheritdoc />
public class Events : IEvents
{
    private readonly ILogger<Events>? _log;
    private readonly IServiceProvider _services;

    private readonly Dictionary<Type, IList<Delegate>> _handlers = new();
    private readonly List<Delegate> _anyHandlers = new();
    private readonly IEventParser _parser;

    public Events(ILogger<Events>? log, IServiceProvider services, IEventParser parser)
    {
        _log = log;
        _services = services;
        _parser = parser;
    }
    
    public IEnumerable<Type> EventTypes => _handlers.Keys;

    /// <inheritdoc />
    public void On<TEvent>(EventDelegate<TEvent> handler) where TEvent : IEvent
    {
        var eventType = typeof(TEvent);

        if (!_handlers.ContainsKey(eventType))
        {
            _log?.LogDebug("Event {Event} is not registered, registering now", eventType.FullName);
            Register<TEvent>();
        }

        if (_handlers.TryGetValue(eventType, out var handlers))
            handlers.Add(handler);
        else
            _handlers.Add(eventType, new List<Delegate> {handler});
    }

    /// <inheritdoc />
    public void OnAny(EventDelegate<IEvent> handler)
    {
        _anyHandlers.Add(handler);
    }

    /// <inheritdoc />
    public void Invoke<TEvent>(TEvent argument) where TEvent : IEvent
    {
        var eventType = argument.GetType();

        if (!_handlers.ContainsKey(eventType))
        {
            _log?.LogDebug("Event {Event} is not registered, registering now", eventType.FullName);
            Register<TEvent>();
        }

        var handlers = _handlers[eventType];

        foreach (var handler in handlers)
        {
            _log?.LogTrace("Invoking {Handler} handler for event {Event}", handler.Method.Name, eventType.FullName);
            handler.DynamicInvoke(argument);
        }

        foreach (var handler in _anyHandlers)
        {
            _log?.LogTrace("Invoking {Handler} handler for event {Event} (any)", handler.Method.Name,
                eventType.FullName);
            handler.DynamicInvoke(argument);
        }
    }

    /// <inheritdoc />
    public void Invoke(string? json)
    {
        try
        {
            if (string.IsNullOrEmpty(json))
                return;

            var jObject = JObject.Parse(json);
            var eventKey = jObject["event"];

            if (eventKey == null)
            {
                var ex = new JsonException("The JSON does not contain an event key.");
                ex.Data.Add("JSON", json);

                _log?.LogWarning(ex, "Could not parse JSON");
                throw ex;
            }

            var eventName = eventKey.Value<string>();
            var typeName = $"{eventName}Event";

            var eventType = EventTypes.FirstOrDefault(t => t.Name == typeName);

            if (eventType == null)
            {
                _log?.LogWarning("The {Event} event is not registered", eventName);
                return;
            }

            var parsedEvent = _parser.FromJson(eventType, json);

            if (parsedEvent == null)
            {
                var ex = new JsonException($"The specified JSON could not be parsed into {eventName}");
                ex.Data.Add("JSON", json);

                _log?.LogWarning(ex, "Could not parse event {Event}", eventName);
                return;
            }
            
            Invoke(parsedEvent);
        }
        catch (Exception ex)
        {
            ex.Data.Add("JSON", json);
            _log?.LogWarning(ex, "Could not invoke event from JSON");
        }
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
    public void Register<TEvent>() where TEvent : IEvent => Register(typeof(TEvent));

    /// <inheritdoc />
    public void Register(Type? type)
    {
        if (type == null)
            return;

        if (!IsValidEventType(type))
        {
            var ex = new ArgumentException($"{type.FullName} must inherit from {nameof(IEvent)} and end with 'Event'.");   
            _log?.LogWarning(ex, "Could not register {Event}", type.FullName);
            return;
        }

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
            _log?.LogWarning(ex, "Could not register the default events");
        }
    }

    private void AddEvent(Type type)
    {
        var eventName = type.Name.Replace("Event", "");
        
        try
        {
            if (_handlers.Any(x => x.Key.Name == type.Name))
            {
                var oldEvent = _handlers.Keys.First(x => x.Name == type.Name);

                // Return if already registered
                if (oldEvent == type) 
                    return;

                _log?.LogDebug("Reassigning {EventName} from {OldEvent} to {NewEvent}",  eventName, oldEvent.FullName, type.FullName);

                _handlers.Remove(oldEvent);
                _handlers.Add(type, new List<Delegate>());
            }
            else
            {
                _log?.LogTrace("Assigning {EventName} to {Event}", eventName, type.FullName);
                _handlers.Add(type, new List<Delegate>());
            }
        }
        catch (Exception ex)
        {
            _log?.LogWarning(ex, "Could not assign {EventName} to {Event}", eventName, type.FullName);
            throw;
        }
    }

    private static bool IsValidEventType(Type type)
    {
        return type.GetInterfaces().Contains(typeof(IEvent)) && type.Name.EndsWith("Event");
    }
}