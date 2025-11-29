using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EliteAPI.Events;
using EliteAPI.Journals;
using EliteAPI.Json;
using EliteAPI.Utils;
using EliteAPI.Watcher;
using Newtonsoft.Json;

namespace EliteAPI;

public class EliteDangerousApi
{
    private readonly FileWatcher _journalWatcher;
    private readonly List<FileWatcher> _statusWatchers;

    private readonly List<Action<FileInfo>> _journalChangedHandlers = [];
    private readonly List<Action<IEvent>> _typedGlobalEventHandlers = [];
    private readonly List<Action<(string eventName, string json)>> _untypedGlobalEventHandlers = [];
    private readonly Dictionary<string, List<Action<IEvent>>> _typedEventHandlers = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, Type> _eventTypes = typeof(IEvent)
        .Assembly
        .GetTypes()
        .Where(t => typeof(IEvent).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
        .ToDictionary(t => t.Name.EndsWith("Event") ? t.Name.Substring(0, t.Name.Length - 5) : t.Name, t => t, StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, List<Action<(string eventName, string json)>>> _untypedEventHandlers = new(StringComparer.OrdinalIgnoreCase);

    public EliteDangerousApi()
    {
        var journalDirectory = JournalUtils.GetJournalsDirectory();
        string[] statusFiles = [
            "Cargo.json",
            "Market.json",
            "ModulesInfo.json",
            "NavRoute.json",
            "Outfitting.json",
            "ShipLocker.json",
            "Shipyard.json"
        ];

        _statusWatchers = statusFiles
            .Select(fileName => FileWatcher.Create(journalDirectory, fileName, FileWatchMode.EntireFile))
            .ToList();

        _journalWatcher = FileWatcher.Create(journalDirectory, "Journal.*.log", FileWatchMode.LineByLine);
    }

    public void Start()
    {
        _journalWatcher.OnContentChanged((json) =>
        {
            JournalUtils.PrepareLocalisations(json);
            Invoke(json);
        });

        _journalWatcher.OnFileChanged(file =>
        {
            foreach (var handler in _journalChangedHandlers)
                SafeInvoke.Invoke(handler, file);
        });
        _statusWatchers.ForEach(w => w.OnContentChanged(Invoke));
        
        _statusWatchers.ForEach(w => w.StartWatching());
        _journalWatcher.StartWatching();
    }

    /// <summary>
    /// Listens for when a new journal file is being watched
    /// </summary>
    public void OnJournalChanged(Action<FileInfo> handler)
    {
        _journalChangedHandlers.Add(handler);
    }

    /// <summary>
    /// Listens for a specific event of <typeparamref name="TEvent"/>.
    /// </summary>
    public void On<TEvent>(Action<TEvent> handler)
        where TEvent : IEvent
    {
        var eventName = typeof(TEvent).Name;

        // remove "Event" suffix 
        if (eventName.EndsWith("Event"))
            eventName = eventName.Substring(0, eventName.Length - 5);

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
            eventName = eventName.Substring(0, eventName.Length - 5);

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
        Invoke(JsonConvert.SerializeObject(@event, JsonUtils.SerializerSettings), @event);
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

        if (@event == null && _eventTypes.TryGetValue(eventName, out var eventType))
        {
            try
            {
                @event = JsonConvert.DeserializeObject(json, eventType, JsonUtils.SerializerSettings) as IEvent;
            }
            catch (Exception ex)
            {
                // TODO: proper logging
                Console.WriteLine($@"Error: {ex.Message}");
            }

            if (@event == null)
            {
                // TODO: proper logging
                return;
            }
        }

        // invoke untyped handlers
        if (_untypedEventHandlers.TryGetValue(eventName, out var untypedHandlers))
        {
            foreach (var handler in untypedHandlers)
                SafeInvoke.Invoke(handler, (eventName, json));
        }

        // invoke global untyped handlers
        foreach (var handler in _untypedGlobalEventHandlers)
            SafeInvoke.Invoke(handler, (eventName, json));

        if (@event != null)
        {
            // invoke typed handlers
            if (_typedEventHandlers.TryGetValue(eventName, out var typedEventHandlers))
            {
                foreach (var handler in typedEventHandlers)
                    SafeInvoke.Invoke(handler, @event);
            }

            // invoke global typed handlers
            foreach (var handler in _typedGlobalEventHandlers)
                SafeInvoke.Invoke(handler, @event);
        }
    }
}

