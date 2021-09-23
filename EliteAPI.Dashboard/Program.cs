using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using ElectronNET.API;
using EliteAPI.Abstractions;
using EliteAPI.Dashboard.Controllers.EliteVA;
using EliteAPI.Dashboard.Models;
using EliteAPI.Dashboard.Services;
using EliteAPI.Dashboard.WebSockets.Handler;
using EliteAPI.Dashboard.WebSockets.Logging;
using EliteAPI.Dashboard.WebSockets.Message;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Status.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Dashboard
{
    public class Program
    {
        private static IEliteDangerousApi _api;
        private static WebSocketHandler _socketHandler;
        private static VariableService _variableService;
        private static ILogger<Program> _log;
        private static EliteVaInstaller _eliteVaInstaller;

        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            _api = host.Services.GetRequiredService<IEliteDangerousApi>();
            _socketHandler = host.Services.GetRequiredService<WebSocketHandler>();
            _variableService = host.Services.GetRequiredService<VariableService>();
            _eliteVaInstaller = host.Services.GetRequiredService<EliteVaInstaller>();
            _log = host.Services.GetRequiredService<ILogger<Program>>();

            await _api.InitializeAsync();
            
            // Sub to events
            _api.Events.AllEvent += async (sender, e) => await Broadcast("Event", e,true, false);

            // Sub to statuses
            _api.Cargo.OnChange += async (sender, e) => await Broadcast("Cargo",_api.Cargo, true, true);
            _api.Market.OnChange += async (sender, e) => await Broadcast("Market", _api.Market, true, true);
            _api.Modules.OnChange += async (sender, e) => await Broadcast("Modules", _api.Modules, true, true);
            _api.Outfitting.OnChange += async (sender, e) => await Broadcast("Outfitting", _api.Outfitting, true, true);
            _api.Shipyard.OnChange += async (sender, e) => await Broadcast("Shipyard", _api.Shipyard, true, true);
            _api.Ship.OnChange += async (sender, e) => await Broadcast("Status", _api.Ship, true, true);
            _api.NavRoute.OnChange += async (sender, e) => await Broadcast("NavRoute", _api.NavRoute, true, true);
            _api.Backpack.OnChange += async (sender, e) => await Broadcast("Backpack", _api.Backpack, true, true);
            
            // Sub to options
            _api.Bindings.OnChange += async (sender, e) => await _socketHandler.Broadcast(new WebSocketMessage("Bindings", _api.Bindings.ToJson()), true, true);

            // Send latest eliteva version
            await _socketHandler.Broadcast(new WebSocketMessage("EliteVA.Latest", await _eliteVaInstaller.GetLatestVersion()), true, true);

            await _api.StartAsync();
            await host.RunAsync();
        }

        private static async Task Broadcast(string type, IJsonObject value, bool useDuringCatchup, bool onlySaveLatestForCatchup)
        {
            // Broadcast to client
            await _socketHandler.Broadcast(new WebSocketMessage(type, value.ToJson()), WebSocketType.Client, useDuringCatchup, onlySaveLatestForCatchup);
            
            // Broadcast to frontend
            await _socketHandler.Broadcast(new WebSocketMessage(type, value.ToJson()), WebSocketType.FrontEnd, useDuringCatchup, onlySaveLatestForCatchup);
            
            // Broadcast to plugin
            if (new [] {"Event", "Cargo", "Modules", "Outfitting", "Shipyard", "Status", "NavRoute", "Backpack", "Market"}.Contains(type))
            {
                var variables = _variableService.GetVariables(value);
                var name = type;
                if (type != "Event")
                {
                    variables = variables.Select(x => new Variable($"{type}.{x.Name.Replace(".Value", "")}", x.Value, x.Type)).ToList();
                }
                else
                {
                    name = variables.First(x => x.Name == "Event").Value.ToString();
                    variables = variables.Select(x => new Variable($"{name}.{x.Name.Replace(".Value", "")}", x.Value, x.Type)).ToList();
                }

                await _socketHandler.Broadcast(new WebSocketMessage(type, new Models.Event(name, variables)), WebSocketType.Plugin, useDuringCatchup, onlySaveLatestForCatchup);   
                //await _socketHandler.Broadcast(new WebSocketMessage($"{type}-plugin", variables), WebSocketType.FrontEnd, useDuringCatchup, onlySaveLatestForCatchup);   
            }
            else
            {
                await _socketHandler.Broadcast(new WebSocketMessage(type, value), WebSocketType.Plugin, useDuringCatchup, onlySaveLatestForCatchup);
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logger =>
                {
                    logger.ClearProviders();
                    logger.SetMinimumLevel(LogLevel.Debug);
                    // logger.AddPrettyConsole(ConsoleFormats.Default, ConsoleThemes.Vanilla);
                    logger.AddSimpleConsole();
                    logger.AddWebSocketLogger();
                })
                .ConfigureAppConfiguration(config => { config.AddIniFile("EliteAPI.ini", true, true); })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseElectron(args);
                    webBuilder.UseStartup<Startup>();
                });
    }
}
