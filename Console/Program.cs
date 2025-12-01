using EliteAPI;
using EliteAPI.Documentation;
using EliteAPI.Utils;
using Newtonsoft.Json;

// Log.AddListener(log =>
// {


//     ConsoleColor color = log.Level switch
//     {
//         Log.LogLevel.Debug => ConsoleColor.DarkGray,
//         Log.LogLevel.Info => ConsoleColor.Blue,
//         Log.LogLevel.Warning => ConsoleColor.Yellow,
//         Log.LogLevel.Error => ConsoleColor.Red,
//         _ => ConsoleColor.White
//     };

//     var previousColor = Console.ForegroundColor;
//     Console.ForegroundColor = color;
//     Console.WriteLine(log.Message);
//     Console.ForegroundColor = previousColor;
// });

var api = new EliteDangerousApi();

// api.OnKeybindingsChanged(bindings =>
// {
//     foreach (var binding in bindings)
//     {
//         if (binding.Name != "LandingGearToggle")
//             continue;

//         Log.Info(JsonConvert.SerializeObject(binding));
//     }
// });

api.Start();


// api.OnAllJson(handler =>
// {
//     Console.WriteLine(handler.eventName);
//     Console.WriteLine(handler.json);
// });

// api.OnAllJson(e =>
// {
//     Console.WriteLine($"JSON Event: {e.eventName}");
// });

// await Task.Delay(-1);


var server = new Server(api);
await server.Initialize();


Thread.Sleep(-1);
