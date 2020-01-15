using EliteAPI;
using EliteAPI.Discord;
using Somfic.Logging;

using System.IO;
using System.Threading;
using Somfic.Logging.Handlers;

namespace Example
{
    internal class Program
    {
        private static EliteDangerousAPI EliteAPI;

        private static void Main(string[] args)
        {
            EliteAPI = new EliteDangerousAPI();
            EliteAPI.Logger.AddHandler(new ConsoleHandler());
            EliteAPI.Logger.SetAllowedLevels(Severity.Info | Severity.Warning | Severity.Error);
          
            EliteAPI.Start();
            EliteAPI.Events.MarketSellEvent += Events_MarketSellEvent;

            Thread.Sleep(-1);
        }

        private static void Events_MarketSellEvent(object sender, EliteAPI.Events.MarketSellInfo eventArg)
        {
            EliteAPI.Logger.Log("MarketSell event has been triggered", eventArg);
        }
    }
}