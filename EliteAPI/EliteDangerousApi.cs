using EliteAPI.Journals;
using EliteAPI.Json;
using EliteAPI.Watcher;

namespace EliteApi;

public class EliteDangerousApi
{
    private readonly LineByLineFileWatcher _journalWatcher;

    public EliteDangerousApi()
    {
        var journalDirectory = JournalUtils.GetJournalsDirectory();

        _journalWatcher = LineByLineFileWatcher.Create(journalDirectory, "Journal.*.log").watcher;
    }

    public void OnJournalEvent(Action<(string eventName, string json)> onEvent)
    {
        _journalWatcher.OnChange(json =>
        {
            var eventName = JsonUtils.GetEventName(json);
            onEvent((eventName, json));
        });
    }
}
