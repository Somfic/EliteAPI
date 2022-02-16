using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EliteAPI.Abstractions.Events;
using EliteAPI.Abstractions.Events.Converters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace EliteAPI.Events;

/// <inheritdoc />
public class Events : IEvents
{
    private readonly ILogger<Events>? _log;
    private readonly IServiceProvider _services;

    private Dictionary<Type, IList<Delegate>> _eventHandlers = new();
    private Dictionary<Type, IList<Delegate>> _jsonHandlers = new();

    private readonly List<Delegate> _anyEventHandlers = new();
    private readonly List<Delegate> _anyJsonHandlers = new();

    private readonly IEventParser _parser;

    public Events(ILogger<Events>? log, IServiceProvider services, IEventParser parser)
    {
        _log = log;
        _services = services;
        _parser = parser;
    }

    /// <inheritdoc />
    public IEnumerable<Type> EventTypes => _eventHandlers.Keys;

    /// <inheritdoc />
    public void On<TEvent>(EventDelegate<TEvent> handler) where TEvent : IEvent =>
        On<TEvent>(handler, ref _eventHandlers);

    /// <inheritdoc />
    public void On<TEvent>(JsonDelegate handler) where TEvent : IEvent => On<TEvent>(handler, ref _jsonHandlers);

    private void On<TEvent>(Delegate handler, ref Dictionary<Type, IList<Delegate>> delegates) where TEvent : IEvent
    {
        var eventType = typeof(TEvent);

        if (!delegates.ContainsKey(eventType))
            Register<TEvent>();

        if (delegates.TryGetValue(eventType, out var handlers))
            handlers.Add(handler);
        else
            delegates.Add(eventType, new List<Delegate> {handler});
    }

    /// <inheritdoc />
    public void OnAny(EventDelegate<IEvent> handler) => _anyEventHandlers.Add(handler);

    /// <inheritdoc />
    public void OnAny(JsonDelegate handler) => _anyJsonHandlers.Add(handler);

    /// <inheritdoc />
    public void Invoke<TEvent>(TEvent @event, EventContext context) where TEvent : IEvent
    {
        var eventName = @event.GetType().Name.Replace("Event", string.Empty);

        try
        {
            InvokeAnyHandlers(@event, context);
        }
        catch (Exception ex)
        {
            _log?.LogWarning(ex, "Error invoking event handlers for {Event}", eventName);
            throw;
        }
    }

    /// <inheritdoc />
    public void Invoke(string json, EventContext context)
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

            var eventType = EventTypes.FirstOrDefault(t => string.Equals(t.Name, typeName, StringComparison.InvariantCultureIgnoreCase));

            context = new EventContext()
            {
                IsRaisedDuringCatchup = context.IsRaisedDuringCatchup,
                IsImplemented = eventType != null
            };
            
            if (eventType == null)
                _log?.LogWarning("The {Event} event is not registered", eventName);
            
            // Invoke the JSON handlers
            InvokeAnyHandlers(eventType, json, context);

            if (eventType == null)
                return;
            
            var parsedEvent = _parser.FromJson(eventType, json);

            if (parsedEvent == null)
            {
                var ex = new JsonException($"The specified JSON could not be parsed into {eventName}");
                ex.Data.Add("JSON", json);

                _log?.LogWarning(ex, "Could not parse event {Event}", eventName);
                return;
            }

            try
            {
                // Get differences between the JSON and the event
                var parsedJson = JsonConvert.SerializeObject(parsedEvent);

                var pathsRaw = _parser.ToPaths(json).ToList();
                var pathsParsed = _parser.ToPaths(parsedJson).ToList();

                var missingPaths = pathsRaw.Except(pathsParsed).ToList();
                var extraPaths = pathsParsed.Except(pathsRaw).ToList();

                if (missingPaths.Any() || extraPaths.Any())
                {
                    var ex = new JsonException($"The specified JSON does not match the {eventName} event");
                    //ex.Data.Add("JSON", json);
                    ex.Data.Add("MissingPaths", missingPaths);
                    ex.Data.Add("ExtraPaths", extraPaths);

                    //_log?.LogWarning(ex, "Could not parse event {Event}", eventName);
                }
            }
            catch (Exception ex)
            {
                _log?.LogWarning(ex, "Could not find differences between the JSON and the event {Event}", eventName);
            }

            Invoke(parsedEvent, context);
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

    /// <inheritdoc />
    public bool IsRegistered<TEvent>() where TEvent : IEvent
    {
        var type = typeof(TEvent);
        return IsRegistered(type);
    }
    
    /// <inheritdoc />
    public bool IsRegistered(Type? type)
    {
        return type != null && _eventHandlers.ContainsKey(type);
    }

    private void AddEvent(Type type)
    {
        var eventName = type.Name.Replace("Event", "");

        try
        {
            if (_eventHandlers.Any(x => x.Key.Name == type.Name))
            {
                var oldEvent = _eventHandlers.Keys.First(x => x.Name == type.Name);

                // Return if already registered
                if (oldEvent == type)
                    return;

                _log?.LogDebug("Reassigning {EventName} from {OldEvent} to {NewEvent}", eventName, oldEvent.FullName,
                    type.FullName);

                _eventHandlers.Remove(oldEvent);
                _eventHandlers.Add(type, new List<Delegate>());
            }
            else
            {
                _log?.LogTrace("Assigning {EventName} to {Event}", eventName, type.FullName);
                _eventHandlers.Add(type, new List<Delegate>());
            }
        }
        catch (Exception ex)
        {
            _log?.LogWarning(ex, "Could not assign {EventName} to {Event}", eventName, type.FullName);
            throw;
        }
    }

    private void InvokeAnyHandlers<TEvent>(TEvent @event, EventContext context) where TEvent : IEvent
    {
        var eventName = @event.GetType().Name.Replace("Event", string.Empty);

        // Any handlers
        foreach (var handler in _anyEventHandlers)
        {
            try
            {
                _log?.LogTrace("Invoking {Type}:{Handler} handler for event {Event}",
                    handler.Method.DeclaringType?.FullName,
                    handler.Method.Name,
                    eventName);
                handler.DynamicInvoke(@event, context);
            }
            catch (TargetInvocationException ex)
            {
                _log?.LogWarning(ex.InnerException,
                    "Unhandled exception in {Type}:{Handler} handler for event {Event}",
                    handler.Method.DeclaringType?.FullName,
                    handler.Method.Name,
                    eventName);
            }
        }
        
        // Specific handlers
        var eventType = @event.GetType();
        foreach (var handler in _eventHandlers[eventType])
        {
            try
            {
                _log?.LogTrace("Invoking {Type}:{Handler} handler for event {Event}",
                    handler.Method.DeclaringType?.FullName,
                    handler.Method.Name,
                    eventName);
                handler.DynamicInvoke(@event, context);
            }
            catch (TargetInvocationException ex)
            {
                _log?.LogWarning(ex.InnerException,
                    "Unhandled exception in {Type}:{Handler} handler for event {Event}",
                    handler.Method.DeclaringType?.FullName,
                    handler.Method.Name,
                    eventName);
            }
        }
    }

    private void InvokeAnyHandlers(Type? type, string json, EventContext context)
    {
        if (string.IsNullOrEmpty(json))
            return;

        var jObject = JObject.Parse(json);
        var eventKey = jObject["event"];

        if (eventKey == null)
        {
            var ex = new JsonException("The specified JSON does not contain an event key.");
            ex.Data.Add("JSON", json);

            _log?.LogWarning(ex, "Could not parse JSON");
            throw ex;
        }

        var eventName = eventKey.Value<string>();

        // Any handlers
        foreach (var handler in _anyJsonHandlers)
        {
            try
            {
                _log?.LogTrace("Invoking {Type}:{Handler} handler for event {Event}",
                    handler.Method.DeclaringType?.FullName,
                    handler.Method.Name,
                    eventName);
                handler.DynamicInvoke(json, context);
            }
            catch (TargetInvocationException ex)
            {
                _log?.LogWarning(ex.InnerException,
                    "Unhandled exception in {Type}:{Handler} handler for event {Event}",
                    handler.Method.DeclaringType?.FullName,
                    handler.Method.Name,
                    eventName);
            }
        }

        // Specific handlers
        if (type == null)
            return;
        
        foreach (var handler in _jsonHandlers.Where(x => x.Key == type).SelectMany(x => x.Value))
        {
            try
            {
                _log?.LogTrace("Invoking {Type}:{Handler} handler for event {Event}",
                    handler.Method.DeclaringType?.FullName,
                    handler.Method.Name,
                    eventName);
                handler.DynamicInvoke(json, context);
            }
            catch (TargetInvocationException ex)
            {
                _log?.LogWarning(ex.InnerException,
                    "Unhandled exception in {Type}:{Handler} handler for event {Event}",
                    handler.Method.DeclaringType?.FullName,
                    handler.Method.Name,
                    eventName);
            }
        }
    }

    private static bool IsValidEventType(Type type)
    {
        return type.GetInterfaces().Contains(typeof(IEvent)) && type.Name.EndsWith("Event");
    }
}