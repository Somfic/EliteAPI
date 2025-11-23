using EliteApi;
using EliteAPI.Journals;
using EliteAPI.Json;

var json = await File.ReadAllTextAsync("./EliteAPI.Tests/TestFiles/Status/StatusCombat.json");
var paths = JournalUtils.ToPaths(json);

foreach (var path in paths)
{
    Console.WriteLine($"{path.Path}: {path.Value} ({path.Type})");
}
