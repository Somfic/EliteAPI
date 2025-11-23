using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EliteAPI.Journals;
using EliteAPI.Json;
using EliteAPI.Watcher;

namespace EliteApi;

public class EliteDangerousApi
{
    private readonly List<FileWatcher> _watchers;

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
        _watchers.ForEach(w => w.StartWatching());
    }

    public void OnPathsChanged(Action<(string command, List<JsonPath> variables)> onPathsChanged)
    {
        _watchers.ForEach(w =>
        {
            w.OnContentChanged(async json =>
            {
                var paths = JournalUtils.ToPaths(json);
                var command = JournalUtils.GetEventName(json);

                onPathsChanged((command, paths));
            });
        });
    }
}
