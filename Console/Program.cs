using EliteApi;
using EliteAPI.Json;

var api = new EliteDangerousApi();
api.OnJournalEvent(e =>
{
    var eventName = JsonUtils.GetEventName(e);
    var paths = JsonUtils.FlattenJson(e).Select(p => p.WithPath($"EliteAPI.{eventName}.{p.Path}")).ToList();
    foreach (var path in paths)
    {
        Console.WriteLine($"{path.Path}: {path.Value} ({path.Type})");
    }
});

Thread.Sleep(-1);
