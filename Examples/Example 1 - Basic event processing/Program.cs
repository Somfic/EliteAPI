using EliteAPI;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Somfic.Logging.Console;
using Somfic.Logging.Console.Themes;

using System.Threading.Tasks;

// Build the host for dependency injection
var host = Host.CreateDefaultBuilder()
    .ConfigureLogging((context, logger) =>
    {
        logger.ClearProviders();
        logger.SetMinimumLevel(LogLevel.Trace);
        logger.AddPrettyConsole(ConsoleThemes.Code);
    })

    .ConfigureServices((context, service) =>
    {
        // Add EliteAPI's services to the depdency injection system
        service.AddEliteAPI();
    })

    .Build();

// Create an instance of our Core class
var core = ActivatorUtilities.CreateInstance<Example.Core>(host.Services);

// Execute the Run method inside our Core class
await core.Run();

// Run forever
await Task.Delay(-1);