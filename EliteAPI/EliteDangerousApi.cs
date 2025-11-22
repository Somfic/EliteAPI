using EliteAPI.Journals;
using EliteAPI.Watcher;

namespace EliteApi;

public class EliteDangerousApi
{
    private readonly FileWatcher _journalWatcher;

    public EliteDangerousApi()
    {
        var journalDirectory = JournalUtils.GetJournalsDirectory();

        _journalWatcher = FileWatcher.Create(journalDirectory, "Journal.*.log", FileWatchMode.LineByLine).watcher;
    }

    public void OnJournalEvent(Action<(string eventName, string json)> onEvent)
    {
        _journalWatcher.OnContentChanged(json =>
        {
            var eventName = JournalUtils.GetEventName(json);
            onEvent((eventName, json));
        });
    }
}
