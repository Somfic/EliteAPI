using EliteAPI.Event.Handler;
using EliteAPI.Event.Processor;
using EliteAPI.Event.Provider;
using EliteAPI.Journal.Directory;
using EliteAPI.Journal.Processor;
using EliteAPI.Journal.Provider;
using Microsoft.Extensions.DependencyInjection;

namespace EliteAPI
{
    public static class EliteDangerousAPIExtensions
    {
        public static IServiceCollection AddEliteAPI<T>(this IServiceCollection services) where T : class, IEliteDangerousAPI
        {   
            services.AddSingleton<IEliteDangerousAPI, EliteDangerousAPI>();

            services.AddSingleton<IEventProvider, EventProvider>();
            services.AddSingleton<IEventProcessor, EventProcessor>();

            services.AddSingleton<IJournalDirectoryProvider, JournalDirectoryProvider>();
            services.AddSingleton<IJournalProvider, JournalProvider>();

            services.AddSingleton<IJournalProcessor, JournalProcessor>();

            return services;
        }
    }
}