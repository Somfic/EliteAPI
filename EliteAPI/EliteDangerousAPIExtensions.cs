using EliteAPI.Abstractions;
using EliteAPI.Event.Processor;
using EliteAPI.Event.Processor.Abstractions;
using EliteAPI.Event.Provider;
using EliteAPI.Event.Provider.Abstractions;
using EliteAPI.Journal.Directory;
using EliteAPI.Journal.Directory.Abstractions;
using EliteAPI.Journal.Processor;
using EliteAPI.Journal.Processor.Abstractions;
using EliteAPI.Journal.Provider;
using EliteAPI.Journal.Provider.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using EliteAPI.Event.Attributes;
using EliteAPI.Event.Module;
using EventHandler = EliteAPI.Event.Handler.EventHandler;

namespace EliteAPI
{
    public static class EliteDangerousAPIExtensions
    {
        /// <summary>
        /// Adds all EliteAPI's necessary services to the <seealso cref="IServiceCollection"/>
        /// </summary>
        public static IServiceCollection AddEliteAPI(this IServiceCollection services, Action<EliteDangerousAPIConfiguration> configuration)
        {
            services.AddSingleton<IEliteDangerousAPI, EliteDangerousAPI>();

            services.AddSingleton<IEventProvider, EventProvider>();

            services.AddTransient<IJournalDirectoryProvider, JournalDirectoryProvider>();
            services.AddTransient<IJournalProvider, JournalProvider>();

            services.AddSingleton<IJournalProcessor, JournalProcessor>();

            services.AddSingleton<EventHandler>();

            EliteDangerousAPIConfiguration configInstance = new EliteDangerousAPIConfiguration();
            configuration.Invoke(configInstance);
            configInstance.AddServices(services);

            return services;
        }
    }

    public class EliteDangerousAPIConfiguration
    {
        private readonly IList<Type> eventModuleimplementations;
        private IList<Type> _eventProcessors;

        internal EliteDangerousAPIConfiguration()
        {
            eventModuleimplementations = new List<Type>();
            _eventProcessors = new List<Type>()
            {
                typeof(EventBaseEventProcessor),
                typeof(AttributeEventProcessor)
            };
        }

        /// <summary>
        /// Add an event module to EliteAPI
        /// </summary>
        /// <typeparam name="T">The event module to be added</typeparam>
        public void AddEventModule<T>() where T : EliteDangerousEventModule
        {
            eventModuleimplementations.Add(typeof(T));
        }

        /// <summary>
        /// Remove the default event processors
        /// </summary>
        public void ClearProcessors()
        {
            _eventProcessors = new List<Type>();
        }

        public void AddProcessor<T>() where T : IEventProcessor
        {
            _eventProcessors.Add(typeof(T));
        }

        internal void AddServices(IServiceCollection services)
        {
            foreach (Type implementation in eventModuleimplementations)
            {
                services.AddSingleton(implementation);
            }

            foreach (Type implementation in _eventProcessors)
            {
                services.AddSingleton(typeof(IEventProcessor), implementation);
            }
        }
    }
}