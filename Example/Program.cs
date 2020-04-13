using EliteAPI;
using EliteAPI.Discord;
using Somfic.Logging;

using System.IO;
using System.Threading;
using Somfic.Logging.Handlers;

namespace Example
{
    internal class Program
    {
        private static EliteDangerousAPI EliteAPI;

        private static void Main(string[] args)
        {
            Logger.AddHandler(new ConsoleHandler());
            EliteAPI = new EliteDangerousAPI(new DirectoryInfo(@"\\DESKTOP-RRQICPT\Users\Lucas\Saved Games\Frontier Developments\Elite Dangerous"));

            EliteAPI.Start();

            Thread.Sleep(-1);
        }
    }
}