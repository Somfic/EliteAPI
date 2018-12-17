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
            DirectoryInfo d = new DirectoryInfo($@"C:\Users\Lucas\Downloads\Elite Dangerous Journals");

            EliteDangerousAPI EliteAPI = new EliteDangerousAPI(d, false);
            EliteAPI.OtherEvent += EliteAPI_OtherEvent;

            foreach (var item in d.GetFiles())
            {
                EliteAPI.ProcessLog(item, true);
            }

            Thread.Sleep(-1);
        }

        private static void EliteAPI_OtherEvent(object sender, dynamic e)
        {
            string @event = e.@event;
            if (!unaddedEvents.Contains(@event)) { unaddedEvents.Add(@event); Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(e)); }
        }
    }   
}
