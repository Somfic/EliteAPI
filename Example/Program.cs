using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

using EliteAPI;
using EliteAPI.EDSM;
using EliteAPI.ThirdParty;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI EliteAPI = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory, false);
            EliteAPI.Logger.UseConsole().UseLogFile(new DirectoryInfo(Directory.GetCurrentDirectory()));
            //EliteAPI.Events.AllEvent += (sender, e) => EliteAPI.Logger.LogInfo(Newtonsoft.Json.JsonConvert.SerializeObject(e));
            EliteAPI.Start();
            Thread.Sleep(-1);
        }
    }
}