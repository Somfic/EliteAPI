using EliteAPI;
using EliteAPI.Utils;

Log.AddListener(log =>
{
    if (log.Level < Log.LogLevel.Info)
        return;

    ConsoleColor color = log.Level switch
    {
        Log.LogLevel.Debug => ConsoleColor.Gray,
        Log.LogLevel.Info => ConsoleColor.Blue,
        Log.LogLevel.Warning => ConsoleColor.Yellow,
        Log.LogLevel.Error => ConsoleColor.Red
    };

    var previousColor = Console.ForegroundColor;
    Console.ForegroundColor = color;
    Console.WriteLine(log.Message);
    Console.ForegroundColor = previousColor;
});

var api = new EliteDangerousApi();

api.OnAll(e =>
{
    Console.WriteLine($"Event: {e.Event}");
});

api.OnJournalChanged(e =>
{
    Console.WriteLine($"New journal file being watched: {e.FullName}");
});

api.Start();

// api.OnAllJson(e =>
// {
//     Console.WriteLine($"JSON Event: {e.eventName}");
// });

await Task.Delay(-1);
