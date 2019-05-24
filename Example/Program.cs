using EliteAPI;
using EliteAPI.Logging;

using InputManager;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Example
{
    class Program
    {
        static EliteDangerousAPI EliteAPI;

        static void Main(string[] args)
        {
            EliteAPI = new EliteDangerousAPI();
            EliteAPI.Logger.UseConsole(Severity.Debug).UseLogFile(Directory.GetCurrentDirectory());
            EliteAPI.Start();

            EliteAPI.Events.AllEvent += (sender, e) => Console.Beep();

            Thread.Sleep(-1);
        }
    }
}