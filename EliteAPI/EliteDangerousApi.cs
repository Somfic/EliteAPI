using System;
using EliteAPI.Journals;
using EliteAPI.Watcher;

namespace EliteApi;

public class EliteDangerousApi
{
    private readonly FileWatcher _journalWatcher;
    private readonly FileWatcher _statusWatcher;

    public EliteDangerousApi()
    {
        var journalDirectory = JournalUtils.GetJournalsDirectory();

        _journalWatcher = FileWatcher.Create(journalDirectory, "Journal.*.log", FileWatchMode.LineByLine).watcher;
        _statusWatcher = FileWatcher.Create(journalDirectory, "Status.json", FileWatchMode.EntireFile).watcher;
    }

    public void OnJournalEvent(Action<(string eventName, string json)> onEvent)
    {
        _journalWatcher.OnContentChanged(json =>
        {
            var eventName = JournalUtils.GetEventName(json);
            onEvent((eventName, json));
        });

        _statusWatcher.OnContentChanged(json =>
        {
            onEvent(("Status", json));
        });
    }
}
