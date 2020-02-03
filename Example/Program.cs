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
            EliteAPI = new EliteDangerousAPI();
            EliteAPI.Logger.AddHandler(new ConsoleHandler());
            EliteAPI.Logger.AddHandler(new LogFileHandler(Directory.GetCurrentDirectory(), "EliteAPI"));
            EliteAPI.Start();

            Thread.Sleep(-1);
        }
    }
}