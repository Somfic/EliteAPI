using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EliteAPI.Bindings;
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
    private readonly FileWatcher _bindingsPresetsWatcher;
    private readonly StatusTracker _statusTracker = new();

    private readonly List<Action<FileInfo>> _journalChangedHandlers = [];
    private readonly List<Action<(IEvent, EventContext)>> _typedGlobalEventHandlers = [];
    private readonly List<Action<(string eventName, string json, EventContext)>> _untypedGlobalEventHandlers = [];
    private readonly Dictionary<string, List<Action<IEvent>>> _typedEventHandlers = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, Type> _eventTypes = typeof(IEvent)
        .Assembly
        .GetTypes()
        .Where(t => typeof(IEvent).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
        .ToDictionary(t => t.Name.EndsWith("Event") ? t.Name.Substring(0, t.Name.Length - 5) : t.Name, t => t, StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, List<Action<(string eventName, string json)>>> _untypedEventHandlers = new(StringComparer.OrdinalIgnoreCase);
    private readonly List<Action<IReadOnlyCollection<Control>>> _bindingsHandlers = [];

    public EliteDangerousApi()
    {
        string[] statusFiles = [
            "Cargo.json",
            "Market.json",
            "ModulesInfo.json",
            "NavRoute.json",
            "Outfitting.json",
            "ShipLocker.json",
            "Shipyard.json",
            "Status.json"
        ];

        _statusWatchers = statusFiles
            .Select(fileName => FileWatcher.Create(JournalUtils.GetJournalsDirectory(), fileName, FileWatchMode.EntireFile))
            .ToList();

        _journalWatcher = FileWatcher.Create(JournalUtils.GetJournalsDirectory(), "Journal.*.log", FileWatchMode.LineByLine);

        _bindingsPresetsWatcher = FileWatcher.Create(BindingsUtils.GetBindingsDirectory(), "StartPreset*", FileWatchMode.EntireFile);
    }

    public void Start()
    {
        _journalWatcher.OnContentChanged((json) =>
        {
            JournalUtils.PrepareLocalisations(json);
            Invoke(json, new EventContext { SourceFile = _journalWatcher.CurrentFile.Name });
        });
        _journalWatcher.OnFileChanged(file =>
        {
            foreach (var handler in _journalChangedHandlers)
                SafeInvoke.Invoke("handling journal switch", handler, file);
        });
        _statusWatchers.ForEach(w => w.OnContentChanged(content => Invoke(content, new EventContext { SourceFile = w.CurrentFile.Name })));
        _bindingsPresetsWatcher.OnContentChanged(HandleBindingsPreset);

        _statusWatchers.ForEach(w => w.StartWatching());
        _journalWatcher.StartWatching();
        HandleBindingsPreset(_bindingsPresetsWatcher.StartWatching());

    }

    /// <summary>
    /// Listens for when a new journal file is being watched
    /// </summary>
    public void OnJournalChanged(Action<FileInfo> handler)
    {
        _journalChangedHandlers.Add(handler);
    }

    /// <summary>
    /// Listens for when keybindings have changed
    /// </summary>
    public void OnKeybindingsChanged(Action<IReadOnlyCollection<Control>> handler)
    {
        _bindingsHandlers.Add(handler);
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
    public void OnAll(Action<(IEvent, EventContext)> handler)
    {
        _typedGlobalEventHandlers.Add(handler);
    }

    /// <summary>
    /// Listens for all events with raw JSON
    /// </summary>
    public void OnAllJson(Action<(string eventName, string json, EventContext eventContext)> handler)
    {
        _untypedGlobalEventHandlers.Add(handler);
    }

    public void Invoke(IEvent @event, EventContext eventContext)
    {
        Invoke(JsonConvert.SerializeObject(@event, JsonUtils.SerializerSettings), @event, eventContext);
    }

    public void Invoke(string json, EventContext eventContext) => Invoke(json, null, eventContext);

    internal void Invoke(string json, IEvent? @event, EventContext eventContext)
    {
        var eventName = JsonUtils.GetEventName(json);
        if (string.IsNullOrEmpty(eventName))
        {
            Log.Warning("Skipping invalid event with no name.");
            return;
        }

        // Handle Status events specially for change detection
        List<string>? statusChangedFields = null;
        if (eventName == "Status")
        {
            var paths = JournalUtils.ToPaths(json);
            statusChangedFields = _statusTracker.GetChangedFieldNames(paths);
        }

        if (@event == null && _eventTypes.TryGetValue(eventName, out var eventType))
        {
            try
            {
                @event = JsonConvert.DeserializeObject(json, eventType, JsonUtils.SerializerSettings) as IEvent;
            }
            catch (Exception ex)
            {
                Log.Error($"Failed to deserialize event '{eventName}'", ex);
            }

            if (@event == null)
            {
                Log.Warning($"Event '{eventName}' deserialized to null.");
                return;
            }
        }

        // invoke untyped handlers
        if (_untypedEventHandlers.TryGetValue(eventName, out var untypedHandlers))
        {
            foreach (var handler in untypedHandlers)
                SafeInvoke.Invoke($"{eventName} hander", handler, (eventName, json));
        }

        // invoke global untyped handlers
        foreach (var handler in _untypedGlobalEventHandlers)
            SafeInvoke.Invoke($"{eventName} hander", handler, (eventName, json, eventContext));

        if (@event != null)
        {
            // invoke typed handlers
            if (_typedEventHandlers.TryGetValue(eventName, out var typedEventHandlers))
            {
                foreach (var handler in typedEventHandlers)
                    SafeInvoke.Invoke($"{eventName} hander", handler, @event);
            }

            // invoke global typed handlers
            foreach (var handler in _typedGlobalEventHandlers)
                SafeInvoke.Invoke($"{eventName} hander", handler, (@event, eventContext));
        }

        // After Status event is processed and variables are set, invoke change events
        if (eventName == "Status" && statusChangedFields != null)
        {
            var paths = JournalUtils.ToPaths(json);

            // Invoke a synthetic event for each changed field
            foreach (var fieldName in statusChangedFields)
            {
                var syntheticEventName = $"Status.{fieldName}";
                var syntheticJson = $"{{\"event\":\"Status.{fieldName}\",\"timestamp\":\"{DateTime.UtcNow:yyyy-MM-ddTHH:mm:ssZ}\"}}";

                // invoke untyped handlers for synthetic event
                if (_untypedEventHandlers.TryGetValue(syntheticEventName, out var syntheticUntypedHandlers))
                {
                    foreach (var handler in syntheticUntypedHandlers)
                        SafeInvoke.Invoke($"{syntheticEventName} handler", handler, (syntheticEventName, syntheticJson));
                }

                // invoke global untyped handlers for synthetic event
                foreach (var handler in _untypedGlobalEventHandlers)
                    SafeInvoke.Invoke($"{syntheticEventName} handler", handler, (syntheticEventName, syntheticJson, eventContext));
            }

            // Always update the tracker state, even if no fields changed
            _statusTracker.UpdateState(paths);
        }
    }

    private void HandleBindingsPreset(string presetContent)
    {
        // look at the preset that occurs the most 

        var presets = presetContent.Split('\n').Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

        // Make sure all presets use the same format
        if (presets.Count == 0 || presets.Distinct().Count() > 1)
        {
            Log.Warning("Multiple different keybindings preset formats detected, skipping keybindings setup");
            return;
        }

        var preset = presets[0];

        var file = BindingsUtils.GetBindingsDirectory().GetFiles().FirstOrDefault(f => f.Name.StartsWith(preset));

        if (file == null)
        {
            Log.Warning($"Keybindings preset '{preset}' could not be found, skipping keybindings setup");
            return;
        }

        var bindings = BindingParser.Parse(File.ReadAllText(file.FullName));

        Log.Info($"Loaded {bindings.Count} keybindings from preset '{preset}'");

        foreach (var handler in _bindingsHandlers)
            SafeInvoke.Invoke("handling keybindings change", handler, bindings);
    }
}
