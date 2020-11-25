using System.Threading.Tasks;
using EliteAPI;
using Example2.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Somfic.Logging.Console;
using Somfic.Logging.Console.Themes;

namespace Example2
{
    // Creates a new IHost for dependency injection
    // Creates a new instance of our Core class and starts it
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // Build the host for dependency injection
            var host = Host.CreateDefaultBuilder()
                .ConfigureLogging((context, logger) =>
                {
                    logger.ClearProviders();
                    logger.SetMinimumLevel(LogLevel.Debug);
                    logger.AddPrettyConsole(ConsoleThemes.Code);
                })
                .ConfigureServices((context, service) =>
                {
                    // Add EliteAPI's services to the depdency injection system
                    service.AddEliteAPI(config =>
                    {
                        // Add our ChatModule to EliteAPI's event system
                        config.AddEventModule<ChatModule>();
                    });
                })
                .Build();

            // Create an instance of our Core class
            var core = ActivatorUtilities.CreateInstance<Core>(host.Services);

            // Execute the Run method inside our Core class
            await core.Run();

            // Run forever
            await Task.Delay(-1);
        }
    }
}