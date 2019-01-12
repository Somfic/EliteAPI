using System;
using System.IO;
using System.Threading;

using EliteAPI;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI api = new EliteDangerousAPI(new DirectoryInfo(@"C:\Users\Lucas\Saved Games\Frontier Developments\Elite Dangerous"));
            api.Logger.Log += (sender, arg) => Console.WriteLine(arg.Message);
            api.Start();
            api.DiscordRichPresence.TurnOn();

            Thread.Sleep(-1);
        }
    }
}
