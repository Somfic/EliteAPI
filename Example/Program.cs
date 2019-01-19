using System;
using System.Threading;

using EliteAPI;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI api = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory);
            api.DiscordRichPresence.TurnOn();
            api.Logger.Log += (sender, e) => Console.WriteLine(e.Message);
            api.Events.AllEvent += (sender, e) => Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(e));
            api.Start();
        }
    }
}
