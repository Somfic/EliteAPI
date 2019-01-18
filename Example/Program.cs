using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

using EliteAPI;
using EliteAPI.Inara;
using EliteAPI.Inara.Events;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI api = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory);
            api.DiscordRichPresence.TurnOn();
            api.Logger.Log += (sender, e) => Console.WriteLine(e.Message);
            api.Start();

            while(true)
            {
                Console.WriteLine(api.Status.Gear);
            }

            Thread.Sleep(-1);
        }
    }
}
