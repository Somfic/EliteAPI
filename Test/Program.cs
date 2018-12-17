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

            Console.WriteLine(EliteAPI.Status.Lights);
        }

        private static void EliteAPI_OtherEvent(object sender, dynamic e)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(e));
        }
    }   
}
