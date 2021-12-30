using EliteAPI.Web.EDSM;
using EliteAPI.Web.Spansh;
using Example;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Valsom.Logging.PrettyConsole;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddEliteApi();
        services.AddWebApi<EdsmApi>();
        services.AddWebApi<SpanshApi>();
    })
    .ConfigureLogging(logging =>
    {
        logging.SetMinimumLevel(LogLevel.Trace);
        logging.ClearProviders();
        logging.AddPrettyConsole();
    })
    .ConfigureAppConfiguration(config => { config.AddJsonFile("appsettings.json", true, true); })
    .Build();

var core = ActivatorUtilities.CreateInstance<Core>(host.Services);
await core.Run();

await Task.Delay(-1);