using EliteAPI;
using EliteAPI.Discord;
using EliteAPI.EDSM;
using EliteAPI.Inara;


using InputManager;
using Somfic.Logging;
using System; 

using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Example
{
    class Program
    {

        static EliteDangerousAPI EliteAPI;

        static void Main(string[] args)
        {
            EliteAPI = new EliteDangerousAPI();
            EliteAPI.Logger
                .UseConsole(Severity.Debug)
                .UseLogFile(Directory.GetCurrentDirectory());

            EliteAPI.DiscordRichPresence.WithCustomID("12");
            EliteAPI.DiscordRichPresence.TurnOn(false);
            EliteAPI.DiscordRichPresence.UpdatePresence(new RichPresence("In combat", "in Wolf 983"));

            EliteAPI.Start();

            Thread.Sleep(-1);
        }
    }
}