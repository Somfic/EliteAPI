using System;
using EliteAPI;
using EliteAPI.Abstractions;
using EliteAPI.Event.Attributes;
using EliteAPI.Event.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Somfic.Logging.Console;
using Somfic.Logging.Console.Themes;
using System.Threading.Tasks;
using EliteAPI.Event.Module;

namespace Example1
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // Build the host for dependency injection
            IHost host = Host.CreateDefaultBuilder()
                .ConfigureLogging((context, logger) =>
                {
                    logger.ClearProviders();
                    logger.SetMinimumLevel(LogLevel.Debug);
                    logger.AddPrettyConsole(ConsoleThemes.Code);
                })
                .ConfigureServices((context, service) =>
                {
                    service.AddEliteAPI(config =>
                    {
                        config.AddEventModule<ChatModule>();
                    });
                })
                .Build();

            // Create an instance of our app
            Core core = ActivatorUtilities.CreateInstance<Core>(host.Services);
            await core.Run();
        }

        public void TestMethod(SendTextEvent e)
        {

        }
    }

    public class Core
    {
        private readonly IEliteDangerousAPI _api;
        private readonly ILogger<Core> _log;

        protected Core(IEliteDangerousAPI api, ILogger<Core> log)
        {
            _api = api;
            _log = log;
        }

        public async Task Run()
        {
            _api.Events.SendTextEvent += (sender, e) =>
            {
                // This is code is ran every time a text message is sent in-game
                _log.LogInformation("Hello from inside an event! (Method #1)");
            };

            await _api.StartAsync();
            await Task.Delay(-1);
        }
    }

    public class ChatModule : EliteDangerousEventModule
    { 
        private readonly ILogger<ChatModule> _log;

        public ChatModule(ILogger<ChatModule> log, IServiceProvider services) : base(services)
        {
            _log = log;
        }

        [EliteDangerousEvent]
        public void OnChat(SendTextEvent e)
        {
            // This is code is ran every time a text message is sent in-game

            // IEliteDangerousAPI instance properties are available through the EliteDangerousEventModule abstraction
            string apiVersion = EliteAPI.Version.ToString();

            _log.LogInformation("Hello from inside an event! (Method #2)");
        }
    }
}
