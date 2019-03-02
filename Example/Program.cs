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
            //EliteAPI = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory);
            //EliteAPI.Logger.UseConsole().UseLogFile(new DirectoryInfo(Directory.GetCurrentDirectory()));
            ////EliteAPI.Events.AllEvent += (sender, e) => EliteAPI.Logger.LogInfo(Newtonsoft.Json.JsonConvert.SerializeObject(e));
            //EliteAPI.Start();

            //Thread.Sleep(-1);
            Console.ForegroundColor = ConsoleColor.White;
            EDSMConnection edsm = new EDSMConnection();
            Console.WriteLine(edsm.Execute("https://www.edsm.net/api-v1/system", new List<Tuple<string, string>>()));
            Console.Read();
        }
    }
}