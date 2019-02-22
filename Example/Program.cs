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
            EliteAPI = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory);

            EliteAPI.Logger.UseConsole().UseLogFile();

            EliteAPI.Start();

            EliteAPI.Logger.LogWarning("ERROR", new NotImplementedException());

            Thread.Sleep(-1);
        }
    }
}