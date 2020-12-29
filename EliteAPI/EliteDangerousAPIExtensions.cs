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
using EliteAPI.Status.Models;
using EliteAPI.Status.Models.Abstractions;
using EliteAPI.Status.Processor;
using EliteAPI.Status.Processor.Abstractions;
using EliteAPI.Status.Provider;
using EliteAPI.Status.Provider.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using EventHandler = EliteAPI.Event.Handler.EventHandler;

namespace EliteAPI
{
    public static class EliteDangerousAPIExtensions
    {
        /// <summary>
        ///     Adds all EliteAPI's necessary services to the <seealso cref="IServiceCollection" />
        /// </summary>
        public static IServiceCollection AddEliteAPI(this IServiceCollection services,
            Action<EliteDangerousApiConfigurationBuilder> configuration = null)
        {
            var configInstance = new EliteDangerousApiConfigurationBuilder();
            configuration?.Invoke(configInstance);
            configInstance.AddServices(services);

            services.AddSingleton<IEliteDangerousAPI, EliteDangerousAPI>();

            services.AddSingleton<IEventProvider, EventProvider>();
            services.AddTransient<IJournalDirectoryProvider, JournalDirectoryProvider>();
            services.AddTransient<IJournalProvider, JournalProvider>();
            services.AddTransient<IStatusProvider, StatusProvider>();

            services.AddSingleton<IJournalProcessor, JournalProcessor>();
            services.AddSingleton<IStatusProcessor, StatusProcessor>();

            services.AddSingleton<IShipStatus, ShipStatus>();

            services.AddSingleton<EventHandler>();

            return services;
        }
    }
}