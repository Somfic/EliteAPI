using EliteAPI;
using Somfic.Logging;

using System.IO;
using System.Threading;
using EliteAPI.Utilities;
using Somfic.Logging.Handlers;

namespace Example
{
    internal class Program
    {
        private static EliteDangerousAPI EliteAPI;

        private static DirectoryInfo journalDirectory = new DirectoryInfo(@"\\LUCAS-PC\Users\Lucas\Saved Games\Frontier Developments\Elite Dangerous");

        private static void Main(string[] args)
        {


            Logger.AddHandler(new ConsoleHandler());
            //EliteAPI = new EliteDangerousAPI();

            //EliteAPI.Start();

            JournalReader.StartWatching(journalDirectory);

            Thread.Sleep(-1);
        }
    }
}