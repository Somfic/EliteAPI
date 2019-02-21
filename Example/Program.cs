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
            EliteAPI.Logger.Log += (sender, arg) => Console.WriteLine(arg.Message);

            EliteAPI.Start();

            EliteAPI.Events.AllEvent += (sender, arg) => Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(arg));

            Thread.Sleep(-1);
        }
    }
}