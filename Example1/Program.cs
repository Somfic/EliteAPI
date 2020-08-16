using System;
using System.Threading.Tasks;
using EliteAPI;
using EliteAPI.Event.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Somfic.Logging.Console;
using Somfic.Logging.Console.Themes;

namespace Example1
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder()
                .ConfigureLogging((context, logger) =>
                {
                    logger.ClearProviders();
                    logger.SetMinimumLevel(LogLevel.Debug);
                    logger.AddPrettyConsole(ConsoleThemes.Code);
                })
                .ConfigureServices((context, service) =>
                {
                    service.AddEliteAPI<EliteDangerousAPI>();
                })
                .Build();

            var api = ActivatorUtilities.CreateInstance<EliteDangerousAPI>(host.Services);

            await api.StartAsync();

            await Task.Delay(-1);
        }
    }

    public enum EventPriority
    {
        High, Low

    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class EventHandlerAttribute : Attribute
    {
        public EventHandlerAttribute(EventPriority priority = EventPriority.Low)
        {

        }
    }

    public class CombatModule
    {
        [EventHandler(EventPriority.High)]
        public async Task Bounty(BountyEvent entry, IEliteDangerousAPI api)
        {

        }
    }
}
