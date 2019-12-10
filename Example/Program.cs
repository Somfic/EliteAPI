using EliteAPI;
using EliteAPI.EDSM;
using EliteAPI.Inara;


using InputManager;
using Somfic.Logging;
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
            EliteAPI.Logger.UseConsole(Severity.Debug);
            EliteAPI.Logger.UseLogFile(Directory.GetCurrentDirectory());
            EliteAPI.Logger.UseTCP(500);


            EliteAPI.Start();
            Thread.Sleep(-1);
        }
    }
}