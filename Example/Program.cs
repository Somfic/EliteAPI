using System;
using System.IO;
using System.Threading;
//using System.Windows.Forms;

using EliteAPI;
using EliteAPI.Events;

//using InputManager;

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

            EliteAPI.Events.AllEvent += EliteAPI_DockingGrantedEvent;
            EliteAPI.Logger.Log += (sender, arg) => Console.WriteLine(arg.Message);
            EliteAPI.Events.DockingGrantedEvent += (sender, arg) => Console.WriteLine(arg.LandingPad);

            EliteAPI.Start();
            Thread.Sleep(-1);
        }

        private static void EliteAPI_DockingGrantedEvent(object sender, dynamic e)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(e));
        }
    }
}