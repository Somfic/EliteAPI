using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EliteAPI.Abstractions;
using EliteAPI.Abstractions.Events;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Events;

/// <inheritdoc />
public class Events : IEvents
{
    private readonly ILogger<Events>? _log;

    private Dictionary<Type, IList<(Delegate d, bool hasContext)>> _eventHandlers = new();
    private Dictionary<Type, IList<(Delegate d, bool hasContext)>> _jsonHandlers = new();

    private readonly List<(Delegate d, bool hasContext)> _anyEventHandlers = new();
    private readonly List<(Delegate d, bool hasContext)> _anyJsonHandlers = new();

    private readonly IEventParser _eventParser;

    /// <inheritdoc />
    public IReadOnlyCollection<(IEvent @event, EventContext context)> Backlog => _backlog.AsReadOnly();
    private readonly List<(IEvent @event, EventContext context)> _backlog = new();

    public Events(ILogger<Events>? log, IEventParser eventParser)
    {
        _log = log;
        _eventParser = eventParser;
    }

    /// <inheritdoc />
    public IEnumerable<Type> EventTypes => _eventHandlers.Keys;

    /// <inheritdoc />
    public IReadOnlyCollection<(IEvent @event, EventContext context)> PreviousEvents => _previousEvents.AsReadOnly();

    private List<(IEvent @event, EventContext context)> _previousEvents = new();

    /// <inheritdoc />
    public void On<TEvent>(EventContextDelegate<TEvent> handler) where TEvent : IEvent =>
        On<TEvent>(handler, ref _eventHandlers, true);

    /// <inheritdoc />
    public void On<TEvent>(EventDelegate<TEvent> handler) where TEvent : IEvent =>
        On<TEvent>(handler, ref _eventHandlers, false);

    /// <inheritdoc />
    public void On<TEvent>(AsyncEventContextDelegate<TEvent> handler) where TEvent : IEvent =>
        On<TEvent>(handler, ref _eventHandlers, true);

    /// <inheritdoc />
    public void On<TEvent>(AsyncEventDelegate<TEvent> handler) where TEvent : IEvent =>
        On<TEvent>(handler, ref _eventHandlers, false);

    /// <inheritdoc />
    public void OnJson<TEvent>(JsonContextDelegate handler) where TEvent : IEvent =>
        On<TEvent>(handler, ref _jsonHandlers, true);

    /// <inheritdoc />
    public void OnJson<TEvent>(JsonDelegate handler) where TEvent : IEvent =>
        On<TEvent>(handler, ref _jsonHandlers, false);

    /// <inheritdoc />
    public void OnJson<TEvent>(AsyncJsonContextDelegate handler) where TEvent : IEvent =>
        On<TEvent>(handler, ref _jsonHandlers, true);

    /// <inheritdoc />
    public void OnJson<TEvent>(AsyncJsonDelegate handler) where TEvent : IEvent =>
        On<TEvent>(handler, ref _jsonHandlers, false);

    /// <inheritdoc />
    public void OnAny(EventContextDelegate<IEvent> handler) =>
        _anyEventHandlers.Add((handler, true));

    /// <inheritdoc />
    public void OnAny(EventDelegate<IEvent> handler) =>
        _anyEventHandlers.Add((handler, false));

    /// <inheritdoc />
    public void OnAny(AsyncEventContextDelegate<IEvent> handler) =>
        _anyEventHandlers.Add((handler, true));

    /// <inheritdoc />
    public void OnAny(AsyncEventDelegate<IEvent> handler) =>
        _anyEventHandlers.Add((handler, false));

    /// <inheritdoc />
    public void OnAnyJson(JsonContextDelegate handler) =>
        _anyJsonHandlers.Add((handler, true));

    /// <inheritdoc />
    public void OnAnyJson(JsonDelegate handler) =>
        _anyJsonHandlers.Add((handler, false));

    /// <inheritdoc />
    public void OnAnyJson(AsyncJsonContextDelegate handler) =>
        _anyJsonHandlers.Add((handler, true));

    /// <inheritdoc />
    public void OnAnyJson(AsyncJsonDelegate handler) =>
        _anyJsonHandlers.Add((handler, false));

    /// <inheritdoc />
    public TEvent WaitFor<TEvent>() where TEvent : IEvent => 
        WaitFor<TEvent>(_ => true);
    
    /// <inheritdoc />
    public TEvent WaitFor<TEvent>(Predicate<TEvent> predicate) where TEvent : IEvent => 
        WaitFor(predicate, () => false)!;
    

    /// <inheritdoc />
    public TEvent? WaitFor<TEvent>(int timeout) where TEvent : IEvent => 
        WaitFor<TEvent>(_ => true, timeout);
    
    /// <inheritdoc />
    public TEvent? WaitFor<TEvent>(Predicate<TEvent> predicate, int timeout) where TEvent : IEvent => 
        WaitFor(predicate, TimeSpan.FromMilliseconds(timeout));

    /// <inheritdoc />
    public TEvent? WaitFor<TEvent>(TimeSpan timeout) where TEvent : IEvent => WaitFor<TEvent>(_ => true, timeout);
    
    /// <inheritdoc />
    public TEvent? WaitFor<TEvent>(Predicate<TEvent> predicate, TimeSpan timeout) where TEvent : IEvent
    {
        var started = DateTime.Now;
        return WaitFor(predicate, () => DateTime.Now - started > timeout);
    }
    
    /// <inheritdoc />
    public TEvent? WaitFor<TEvent>(CancellationToken cancellationToken) where TEvent : IEvent => WaitFor<TEvent>(_ => true, cancellationToken);
    
    /// <inheritdoc />
    public TEvent? WaitFor<TEvent>(Predicate<TEvent> predicate, CancellationToken cancellationToken) where TEvent : IEvent =>
        WaitFor(predicate, () => cancellationToken.IsCancellationRequested);

    /// <inheritdoc />
    public TEvent? WaitFor<TEvent>(Func<bool> stopCondition) where TEvent : IEvent => WaitFor<TEvent>(_ => true, stopCondition);

    /// <inheritdoc />
    public TEvent? WaitFor<TEvent>(Predicate<TEvent> predicate, Func<bool> stopCondition) where TEvent : IEvent
    {
        var type = typeof(TEvent);
        var count = CountMatchingEvents<TEvent>();

        while (true)
        {
            if (stopCondition.Invoke())
                return default;
            
            var newCount = CountMatchingEvents<TEvent>();

            if (newCount <= count)
            {
                Thread.Sleep(500);
                continue;
            }

            var @event = (TEvent)_previousEvents.Last(x => x.@event.GetType() == type && !x.context.IsRaisedDuringCatchup).@event;

            if (predicate(@event))
                return @event;
            
            count = newCount;
        }
    }
    
    private int CountMatchingEvents<TEvent>()
    {
        return _previousEvents.Count(x => x.@event.GetType() == typeof(TEvent) && !x.context.IsRaisedDuringCatchup);
    }

    /// <inheritdoc />
    public void Invoke<TEvent>(TEvent @event, EventContext context) where TEvent : IEvent
    {
        _backlog.Add((@event, context));
        
        var eventName = @event.GetType().Name.Replace("Event", string.Empty);

        try
        {
            InvokeAnyHandlers(@event, context);
            _previousEvents.Add((@event, context));
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
                var ex = new JsonException("The JSON does not contain an event key");
                ex.Data.Add("JSON", json);

                _log?.LogWarning(ex, "Could not parse JSON");
                throw ex;
            }

            var eventName = eventKey.Value<string>();
            var typeName = $"{eventName}Event";

            var eventType = EventTypes.FirstOrDefault(t =>
                string.Equals(t.Name, typeName, StringComparison.InvariantCultureIgnoreCase));

            // Update the IsImplemented field on the context
            context = context with { IsImplemented = eventType != null };

            if (eventType == null)
                _log?.LogWarning("The {Event} event is not registered", eventName);

            // Invoke the JSON handlers
            InvokeAnyHandlers(eventType, json, context);

            if (eventType == null)
                return;

            var parsedEvent = _eventParser.FromJson(eventType, json);

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

                var pathsRaw = _eventParser.ToPaths(json).ToList();
                var pathsParsed = _eventParser.ToPaths(parsedJson).ToList();

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
                _log?.LogTrace(ex, "Could not find differences between the JSON and the event {Event}", eventName);
            }

            Invoke(parsedEvent, context);
        }
        catch (Exception ex)
        {
            ex.Data.Add("JSON", json);
            ex.Data.Add("File", context.SourceFile);
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

    private void On<TEvent>(Delegate handler, ref Dictionary<Type, IList<(Delegate d, bool hasContext)>> delegates,
        bool hasContext) where TEvent : IEvent
    {
        var eventType = typeof(TEvent);

        if (!delegates.ContainsKey(eventType))
            Register<TEvent>();

        if (delegates.TryGetValue(eventType, out var handlers))
            handlers.Add((handler, hasContext));
        else
            delegates.Add(eventType, new List<(Delegate d, bool hasContext)> { (handler, hasContext) });
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
                _eventHandlers.Add(type, new List<(Delegate d, bool hasContext)>());
            }
            else
            {
                _log?.LogTrace("Assigning {EventName} to {Event}", eventName, type.FullName);
                _eventHandlers.Add(type, new List<(Delegate d, bool hasContext)>());
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
        foreach (var (d, hasContext) in _anyEventHandlers)
        {
            Invoke(d, @event, hasContext, context, eventName);
        }

        // Specific handlers
        var eventType = @event.GetType();
        foreach (var (d, hasContext) in _eventHandlers[eventType])
        {
            Invoke(d, @event, hasContext, context, eventName);
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

        var eventName = eventKey.Value<string>()!;

        // Any handlers
        foreach (var (d, hasContext) in _anyJsonHandlers)
        {
            Invoke(d, json, hasContext, context, eventName);
        }

        // Specific handlers
        if (type == null)
            return;

        foreach (var (d, hasContext) in _jsonHandlers.Where(x => x.Key == type).SelectMany(x => x.Value))
        {
            Invoke(d, json, hasContext, context, eventName);
        }
    }

    private void Invoke(Delegate d, object param, bool hasContext, EventContext context, string eventName)
    {
        _log?.LogTrace("Invoking {Type}:{Handler} handler for event {Event}",
            d.Method.DeclaringType?.FullName,
            d.Method.Name,
            eventName);

        var isAsync = d.Method.ReturnType == typeof(Task);

        try
        {
            var result = hasContext ? d.DynamicInvoke(param, context) : d.DynamicInvoke(param);

            if (isAsync && result != null)
                (result as Task)!.GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            if (ex is TargetInvocationException && ex.InnerException != null)
                ex = ex.InnerException;

            _log?.LogWarning(ex,
                "Unhandled exception in handler {Type}:{Handler} for event {Event}",
                d.Method.DeclaringType?.FullName,
                d.Method.Name,
                eventName);
        }
    }

    private static bool IsValidEventType(Type type)
    {
        return type.GetInterfaces().Contains(typeof(IEvent)) && type.Name.EndsWith("Event");
    }
}