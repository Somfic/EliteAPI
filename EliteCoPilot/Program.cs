using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EliteAPI;
using EliteCoPilot.Services;

namespace EliteCoPilot
{
    class Program
    {
        private static EliteDangerousAPI EliteAPI;

        private static ServiceHandler ServiceHandler;

        static void Main(string[] args)
        {

            //Create new EliteDangerousAPI object.
            EliteAPI = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory);
            EliteAPI.Logger.UseLogFile(new DirectoryInfo(Directory.GetCurrentDirectory())).UseConsole();

            //Create new ServiceHandler;
            ServiceHandler = new ServiceHandler(EliteAPI);

            //Set services.
            ServiceHandler.UseService(new Docking());

            //Start services.
            ServiceHandler.StartServices();

            //Start EliteAPI.
            EliteAPI.Start();

            //Run forever.
            Thread.Sleep(-1);
        }
    }
}
