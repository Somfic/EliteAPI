using EliteAPI;
using EliteAPI.Discord;
using Somfic.Logging;

using System.IO;
using System.Threading;

namespace Example
{
    internal class Program
    {
        private static EliteDangerousAPI EliteAPI;

        private static void Main(string[] args)
        {
            EliteAPI = new EliteDangerousAPI();
            EliteAPI.Logger
                .UseConsole(Severity.Debug)
                .UseLogFile(Directory.GetCurrentDirectory());

            EliteAPI.Start();

            Thread.Sleep(-1);
        }
    }
}