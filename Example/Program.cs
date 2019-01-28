using System.IO;
using System.Threading;
using System.Windows.Forms;

using EliteAPI;
using EliteAPI.Events;

using InputManager;

using Microsoft.Extensions.DependencyInjection;

namespace Example
{
    class Program
    {
        private static EliteDangerousAPI EliteAPI;

        static void Main(string[] args)
        {
            EliteDangerousAPI api = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory, false);
            api.Logger.Log += (sender, arg) => System.Console.WriteLine(arg.Message);
            api.Start();
            api.Events.AllEvent += (sender, arg) => System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(arg));
            while (true) { System.Console.WriteLine(api.Commander.Credits); }
        }
    }
}
