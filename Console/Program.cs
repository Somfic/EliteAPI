using EliteApi;
using EliteAPI.Json;

var api = new EliteDangerousApi();
api.OnJournalEvent(e =>
{
    var paths = JsonUtils.FlattenJson(e.json).Select(p => p.WithPath($"EliteAPI.{e.eventName}.{p.Path}")).ToList();

    foreach (var path in paths)
        Console.WriteLine($"{path.Path}: {path.Value} ({path.Type})");

    Console.WriteLine($"((EliteAPI.{e.eventName}))");
});

Thread.Sleep(-1);
