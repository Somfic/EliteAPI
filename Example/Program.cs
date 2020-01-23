using EliteAPI;
using Somfic.Logging;
using Somfic.Logging.Handlers;
using System.Threading;
using System.Windows.Forms;
using InputManager;

namespace Example
{
    internal class Program
    {
        private static EliteDangerousAPI EliteAPI;

        private static void Main(string[] args)
        {
            EliteAPI = new EliteDangerousAPI();
            EliteAPI.Logger.AddHandler(new ConsoleHandler());

            EliteAPI.Events.StatusInNoFireZoneEvent += Events_StatusInNoFireZoneEvent;
            EliteAPI.Start();

            Thread.Sleep(-1);
        }

        private static void Events_StatusInNoFireZoneEvent(object sender, EliteAPI.Events.StatusEvent e)
        {
            // Will be called every time we enter or leave a no-fire zone.
            if (!EliteAPI.Status.InNoFireZone) { return; } // If we aren't in a no-fire zone anymore, return.
            if (!EliteAPI.Status.Hardpoints) { return; } // If the hardpoints aren't deployed, return.

            // If everything's good, retract the hardpoints.
            Keyboard.KeyPress(Keys.U);
        }
    }
}