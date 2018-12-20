using EliteAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Example
{
    class Program
    {

        private static List<string> unaddedEvents = new List<string>();

        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo($@"C:\Users\Lucas\Saved Games\Frontier Developments\Elite Dangerous");

            EliteDangerousAPI EliteAPI = new EliteDangerousAPI(d, false);
            EliteAPI.OtherEvent += EliteAPI_OtherEvent;
            EliteAPI.Start();

            Thread.Sleep(-1);
        }

        private static void EliteAPI_OtherEvent(object sender, dynamic e)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(e);
            Console.Beep();
            Console.WriteLine(json);
            File.AppendAllText(@"C:\ICT\EliteAPI\NotAddedEvents.txt", json + Environment.NewLine);
        }
    }   
}
