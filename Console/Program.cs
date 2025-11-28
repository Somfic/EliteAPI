using EliteAPI;
using EliteAPI.Journals;

var api = new EliteDangerousApi();
api.OnAllJson(e => Console.WriteLine($"{e.eventName}: {e.json}"));

var json = await File.ReadAllTextAsync("./EliteAPI.Tests/TestFiles/Status/StatusCombat.json");
var paths = JournalUtils.ToPaths(json);

foreach (var path in paths)
{
    Console.WriteLine($"{path.Path}: {path.Value} ({path.Type})");
}
