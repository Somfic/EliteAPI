using EliteAPI;
using EliteAPI.EDSM;
using EliteAPI.Inara;
using EliteAPI.Logging;

using InputManager;
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
            EliteAPI.Logger.UseConsole(Severity.Debug).UseLogFile(Directory.GetCurrentDirectory());
            EliteAPI.DiscordRichPresence.TurnOn();

            EliteAPI.Events.DockedEvent += (sender, e) =>
            {
                InaraConnection inara = new InaraConnection();
                inara.EventsQueue.Add(new InaraEvent(new EliteAPI.Inara.Events.SetCommanderCredits(EliteAPI.Commander.Credits)));

                inara.ExecuteQueue(new InaraConfiguration("9auf63ovovgosoo008cowwscogkk4sggsswwwkc", "EliteAPI", "1.0.0"));
            };

            EliteAPI.Start();
            Thread.Sleep(-1);
        }
    }
}