using EliteAPI;
using EliteAPI.Logging;

using InputManager;
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
            EliteAPI.Start();

            EliteAPI.Events.StatusInNoFireZoneEvent += StatusInNoFireZoneEvent;
            EliteAPI.Events.ProspectedAsteroidEvent += Events_ProspectedAsteroidEvent;


            Thread.Sleep(-1);
        }

        private static void Events_ProspectedAsteroidEvent(object sender, EliteAPI.Events.ProspectedAsteroidInfo e)
        {
            EliteAPI.Logger.LogInfo(e);
        }

        private static void StatusInNoFireZoneEvent(object sender, EliteAPI.Events.StatusEvent e)
        {
            //This will be ran every time we enter or leave a no-fire-zone.

            //If we're no longer in a no-fire-zone (we've left it), return.
            if(e.Value == false) { return; }

            //Retract the hardpoints if they're deployed.
            if(EliteAPI.Status.Hardpoints == true) { Keyboard.KeyPress(Keys.L); }
        }
    }
}