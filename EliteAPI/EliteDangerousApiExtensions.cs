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
using EliteAPI.Options.Bindings;
using EliteAPI.Options.Bindings.Models;
using EliteAPI.Options.Directory;
using EliteAPI.Options.Directory.Abstractions;
using EliteAPI.Options.Processor;
using EliteAPI.Options.Processor.Abstractions;
using EliteAPI.Options.Provider;
using EliteAPI.Options.Provider.Abstractions;
using EliteAPI.Services.FileReader;
using EliteAPI.Services.FileReader.Abstractions;
using EliteAPI.Status.Cargo;
using EliteAPI.Status.Cargo.Abstractions;
using EliteAPI.Status.Commander;
using EliteAPI.Status.Commander.Abstractions;
using EliteAPI.Status.Market;
using EliteAPI.Status.Market.Abstractions;
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

            // EliteAPI
            services.AddSingleton<IEliteDangerousApi, EliteDangerousApi>();

            // Events
            services.AddTransient<IJournalDirectoryProvider, JournalDirectoryProvider>();
            services.AddTransient<IJournalProvider, JournalProvider>();
            services.AddSingleton<IJournalProcessor, JournalProcessor>();
            services.AddSingleton<IEventProvider, EventProvider>();
            services.AddSingleton<EventHandler>();

            // Status
            services.AddTransient<IStatusProvider, StatusProvider>();
            services.AddSingleton<IStatusProcessor, StatusProcessor>();
            services.AddSingleton<IShip, Ship>();
            services.AddSingleton<ICommander, Commander>();
            services.AddSingleton<IBackpack, Backpack>();
            services.AddSingleton<IShipyard, Shipyard>();
            services.AddSingleton<INavRoute, NavRoute>();
            services.AddSingleton<ICargo, Cargo>();
            services.AddSingleton<IMarket, Market>();
            services.AddSingleton<IModules, Modules>();
            services.AddSingleton<IOutfitting, Outfitting>();

            // Options
            services.AddTransient<IOptionsDirectoryProvider, OptionsDirectoryProvider>();
            services.AddTransient<IOptionsProvider, OptionsProvider>();
            services.AddSingleton<IOptionsProcessor, OptionsProcessor>();
            services.AddSingleton<IBindings, Bindings>();

            // Util
            services.AddTransient<IFileReader, FileReader>();

            return services;
        }
    }
}