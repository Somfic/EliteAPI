using System;
using System.IO;
using System.Windows.Forms;

using EliteAPI;
using EliteAPI.Events;

using InputManager;

namespace Example
{
    class Program
    {
        private static EliteDangerousAPI EliteAPI;

        static void Main(string[] args)
        {
            DirectoryInfo playerJournalFolder = new DirectoryInfo(
            $@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous");

            EliteAPI = new EliteDangerousAPI(playerJournalFolder);

            EliteAPI.Events.DockingGrantedEvent += EliteAPI_DockingGrantedEvent;

            EliteAPI.Start();
        }

        private static void EliteAPI_DockingGrantedEvent(object sender, DockingGrantedInfo e)
        {
            //This method will be ran every time the player is allowed to dock.
            if(EliteAPI.Status.Gear != true) //If the gear is not deployed, deploy it.
            {
                Keyboard.KeyPress(Keys.G);
            }
        }
    }
}
