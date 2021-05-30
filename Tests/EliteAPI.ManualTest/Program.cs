using EliteAPI;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

using EliteAPI.ManualTest;
using EliteAPI.Spansh;
using Valsom.Logging.PrettyConsole;
using Valsom.Logging.PrettyConsole.Formats;
using Valsom.Logging.PrettyConsole.Themes;

// Build the host for dependency injection
var host = Host.CreateDefaultBuilder()
    .ConfigureLogging((context, logger) =>
    {
        logger.ClearProviders();
        logger.SetMinimumLevel(LogLevel.Trace);
        logger.AddPrettyConsole(ConsoleFormats.Default, ConsoleThemes.OneDarkPro);
    })

    .ConfigureServices((context, services) =>
    {
        services.AddEliteAPI(configuration =>
        {

        });

        services.AddSpansh();
    })

    .Build();

var core = ActivatorUtilities.CreateInstance<Core>(host.Services);

await core.Run();

await Task.Delay(-1);