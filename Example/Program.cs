using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

using EliteAPI;
using EliteAPI.EDSM;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI EliteAPI = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory);
            EliteAPI.Logger.UseConsole().UseLogFile(new DirectoryInfo(Directory.GetCurrentDirectory()));
            EliteAPI.Events.AllEvent += (sender, e) => EliteAPI.Logger.LogInfo(Newtonsoft.Json.JsonConvert.SerializeObject(e));
            EliteAPI.Start();
            EliteAPI.DiscordRichPresence.TurnOn();
            Thread.Sleep(-1);
        }
    }
}