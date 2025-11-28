using System;
using System.Collections.Generic;
using System.Linq;
using EliteAPI.Events;
using EliteAPI.Journals;
using EliteAPI.Json;
using EliteAPI.Watcher;
using Newtonsoft.Json;

namespace EliteAPI;

public class EliteDangerousApi
{
    private readonly List<FileWatcher> _watchers;

    private readonly List<Action<IEvent>> _typedGlobalEventHandlers = [];
    private readonly List<Action<(string eventName, string json)>> _untypedGlobalEventHandlers = [];
    private readonly Dictionary<string, List<Action<IEvent>>> _typedEventHandlers = [];
    private readonly Dictionary<string, List<Action<(string eventName, string json)>>> _untypedEventHandlers = [];

    public EliteDangerousApi()
    {
        var journalDirectory = JournalUtils.GetJournalsDirectory();

        var watchers = new Dictionary<string, FileWatchMode>
        {
            { "Journal.*.log", FileWatchMode.LineByLine },
            { "Cargo.json", FileWatchMode.EntireFile },
            { "Market.json", FileWatchMode.EntireFile },
            { "ModulesInfo.json", FileWatchMode.EntireFile },
            { "NavRoute.json", FileWatchMode.EntireFile },
            { "Outfitting.json", FileWatchMode.EntireFile },
            { "ShipLocker.json", FileWatchMode.EntireFile },
            { "Shipyard.json", FileWatchMode.EntireFile },
            { "Status.json", FileWatchMode.EntireFile },
        };

        _watchers = [.. watchers.Select(w => FileWatcher.Create(journalDirectory, w.Key, w.Value))];
    }

    public void Start()
    {
        _watchers.ForEach(w => w.OnContentChanged(json => Invoke(json)));
        _watchers.ForEach(w => w.StartWatching());
    }

    /// <summary>
    /// Listens for a specific event of <typeparamref name="TEvent"/>.
    /// </summary>
    public void On<TEvent>(Action<TEvent> handler)
        where TEvent : IEvent
    {
        var eventName = typeof(TEvent).GetType().Name;

        // remove "Event" suffix 
        if (eventName.EndsWith("Event"))
            eventName = eventName[..^5];

        // initialize list if not exists
        if (!_typedEventHandlers.ContainsKey(eventName))
            _typedEventHandlers[eventName] = [];

        // add handler
        _typedEventHandlers[eventName].Add(e => handler((TEvent)e));
    }

    /// <summary>
    /// Listens for a specific event with the event name of <paramref name="eventName"/> and provides the raw JSON.
    /// </summary>
    public void OnJson(string eventName, Action<(string eventName, string json)> handler)
    {
        // remove "Event" suffix 
        if (eventName.EndsWith("Event"))
            eventName = eventName[..^5];

        // initialize list if not exists
        if (!_untypedEventHandlers.ContainsKey(eventName))
            _untypedEventHandlers[eventName] = [];

        // add handler
        _untypedEventHandlers[eventName].Add(handler);
    }

    /// <summary>
    /// Listens for all events which are typed.
    /// </summary>
    public void OnAll(Action<IEvent> handler)
    {
        _typedGlobalEventHandlers.Add(handler);
    }

    /// <summary>
    /// Listens for all events with raw JSON
    /// </summary>
    public void OnAllJson(Action<(string eventName, string json)> handler)
    {
        _untypedGlobalEventHandlers.Add(handler);
    }

    internal void Invoke(IEvent @event)
    {
        Invoke(JsonConvert.SerializeObject(@event), @event);
    }

    internal void Invoke(string json) => Invoke(json, null);

    internal void Invoke(string json, IEvent? @event)
    {
        var eventName = JsonUtils.GetEventName(json);
        if (string.IsNullOrEmpty(eventName))
        {
            // TODO: proper logging system for this
            Console.WriteLine("Skipping invalid event with no name.");
            return;
        }

        if (@event == null && _typedEventHandlers.ContainsKey(eventName))
        {
            var eventType = _typedEventHandlers[eventName].First().Method.GetParameters()[0].ParameterType;
            @event = JsonConvert.DeserializeObject(json, eventType) as IEvent;

            if (@event == null)
            {
                // TODO: proper logging
                Console.WriteLine($"Failed to deserialize event {eventName} to type {eventType.Name}.");
                return;
            }
        }

        // invoke untyped handlers
        if (_untypedEventHandlers.ContainsKey(eventName))
        {
            foreach (var handler in _untypedEventHandlers[eventName])
            {
                try
                {
                    handler((eventName, json));
                }
                catch (Exception ex)
                {
                    // TODO: proper logging
                    Console.WriteLine($"Error invoking handler for event {eventName}: {ex}");
                }
            }
        }

        // invoke global untyped handlers
        foreach (var handler in _untypedGlobalEventHandlers)
        {
            try
            {
                handler((eventName, json));
            }
            catch (Exception ex)
            {
                // TODO: proper logging
                Console.WriteLine($"Error invoking global untyped handler: {ex}");
            }
        }

        if (@event != null)
        {
            // invoke typed handlers
            if (_typedEventHandlers.ContainsKey(eventName))
            {
                foreach (var handler in _typedEventHandlers[eventName])
                {
                    try
                    {
                        handler(@event);
                    }
                    catch (Exception ex)
                    {
                        // TODO: proper logging
                        Console.WriteLine($"Error invoking handler for event {eventName}: {ex}");
                    }
                }
            }

            // invoke global typed handlers
            foreach (var handler in _typedGlobalEventHandlers)
            {
                try
                {
                    handler(@event);
                }
                catch (Exception ex)
                {
                    // TODO: proper logging
                    Console.WriteLine($"Error invoking global typed handler: {ex}");
                }
            }
        }
    }

    public void OnJson(Action<object, object> value)
    {
        throw new NotImplementedException();
    }
}

