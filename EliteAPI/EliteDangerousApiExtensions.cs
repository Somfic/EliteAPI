using System;

using EliteAPI.Abstractions;
using EliteAPI.Configuration;
using EliteAPI.Event.Provider;
using EliteAPI.Event.Provider.Abstractions;
using EliteAPI.Journal.Directory;
using EliteAPI.Journal.Directory.Abstractions;
using EliteAPI.Journal.Processor;
using EliteAPI.Journal.Processor.Abstractions;
using EliteAPI.Journal.Provider;
using EliteAPI.Journal.Provider.Abstractions;
using EliteAPI.Services.FileReader;
using EliteAPI.Services.FileReader.Abstractions;
using EliteAPI.Status.Cargo;
using EliteAPI.Status.Cargo.Abstractions;
using EliteAPI.Status.Market;
using EliteAPI.Status.Market.Abstractions;
using EliteAPI.Status.Models.Abstractions;
using EliteAPI.Status.Modules;
using EliteAPI.Status.Modules.Abstractions;
using EliteAPI.Status.NavRoute;
using EliteAPI.Status.NavRoute.Abstractions;
using EliteAPI.Status.Outfitting;
using EliteAPI.Status.Outfitting.Abstractions;
using EliteAPI.Status.Processor;
using EliteAPI.Status.Processor.Abstractions;
using EliteAPI.Status.Provider;
using EliteAPI.Status.Provider.Abstractions;
using EliteAPI.Status.Ship;
using EliteAPI.Status.Ship.Abstractions;
using EliteAPI.Status.ShipStatus;

using Microsoft.Extensions.DependencyInjection;

using EventHandler = EliteAPI.Event.Handler.EventHandler;

namespace EliteAPI
{
    [Obsolete("Use EliteDangerousApiExtensions instead", true)]
    public static class EliteDangerousAPIExtensions { }

    public static class EliteDangerousApiExtensions
    {
        /// <summary>
        /// Adds all EliteAPI's necessary services to the <seealso cref="IServiceCollection" />
        /// </summary>
        public static IServiceCollection AddEliteAPI(this IServiceCollection services,
            Action<EliteDangerousApiConfigurationBuilder> configuration = null)
        {
            var configInstance = new EliteDangerousApiConfigurationBuilder();
            configuration?.Invoke(configInstance);
            configInstance.AddServices(services);

            services.AddSingleton<IEliteDangerousApi, EliteDangerousApi>();

            services.AddSingleton<IEventProvider, EventProvider>();
            services.AddTransient<IJournalDirectoryProvider, JournalDirectoryProvider>();
            services.AddTransient<IJournalProvider, JournalProvider>();
            services.AddTransient<IStatusProvider, StatusProvider>();

            services.AddSingleton<IJournalProcessor, JournalProcessor>();
            services.AddSingleton<IStatusProcessor, StatusProcessor>();

            services.AddSingleton<IShip, Ship>();
            services.AddSingleton<IShipStatus, ShipStatus>();
            services.AddSingleton<INavRoute, NavRoute>();
            services.AddSingleton<ICargo, Cargo>();
            services.AddSingleton<IMarket, Market>();
            services.AddSingleton<IModules, Modules>();
            services.AddSingleton<IOutfitting, Outfitting>();

            services.AddSingleton<EventHandler>();

            services.AddTransient<IFileReader, FileReader>();

            return services;
        }
    }
}