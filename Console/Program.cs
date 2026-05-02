using ConsoleHost;
using EliteAPI.Utils;
using EliteVA;

Log.AddListener(log =>
{
    ConsoleColor color = log.Level switch
    {
        Log.LogLevel.Debug => ConsoleColor.DarkGray,
        Log.LogLevel.Info => ConsoleColor.Blue,
        Log.LogLevel.Warning => ConsoleColor.Yellow,
        Log.LogLevel.Error => ConsoleColor.Red,
        _ => ConsoleColor.White
    };

    var previousColor = Console.ForegroundColor;
    Console.ForegroundColor = color;
    Console.WriteLine(log.Message);
    Console.ForegroundColor = previousColor;
});

var proxy = new MockVoiceAttackProxy();

Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true;
    VoiceAttackPluginWrapper.VA_Exit1(proxy);
    Environment.Exit(0);
};

VoiceAttackPluginWrapper.VA_Init1(proxy);

await Task.Delay(-1);
