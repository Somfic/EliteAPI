using System;
using System.Threading;

using System.IO;

using EliteAPI;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI EliteAPI = new EliteDangerousAPI(new DirectoryInfo($@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous"));
            EliteAPI.Start();

            EliteAPI.DockedEvent += EliteAPI_DockedEvent;

            Thread.Sleep(-1);
        }

        private static void EliteAPI_DockedEvent(object sender, DockedInfo e)
        {
            //This method will be ran every time the player docks.
            Console.WriteLine($"Docked at {e.StationName}.");
        }
    }
} 
