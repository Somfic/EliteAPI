using System;
using System.Collections.Generic;
using System.IO;
using EliteAPI.Configuration.Abstractions;
using EliteAPI.Event.Module;
using EliteAPI.Event.Processor;
using EliteAPI.Event.Processor.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace EliteAPI.Configuration
{
    /// <summary>
    /// Creates a <see cref="IEliteDangerousApiConfiguration"/> configuration class through a builder
    /// </summary>
    public class EliteDangerousApiConfigurationBuilder
    {
        private readonly IList<Type> _eventModuleImplementations;
        private IList<Type> _eventProcessors;
        private string _journalDirectory;
        private string _journal;

        internal EliteDangerousApiConfigurationBuilder()
        {
            _eventModuleImplementations = new List<Type>();
            _eventProcessors = new List<Type>
            {
                typeof(EventsEventProcessor),
                typeof(AttributeEventProcessor),
                typeof(AllEventProcessor)
            };
            _journalDirectory = "";
            _journal = "";
        }

        /// <summary>
        ///     Add an event module to EliteAPI
        /// </summary>
        /// <typeparam name="T">The event module to be added</typeparam>
        public void AddEventModule<T>() where T : EliteDangerousEventModule
        {
            _eventModuleImplementations.Add(typeof(T));
        }

        /// <summary>
        ///     Remove the default event processors
        /// </summary>
        public void ClearProcessors()
        {
            _eventProcessors = new List<Type>();
        }

        /// <summary>
        ///     Adds an event processor
        /// </summary>
        /// <typeparam name="T">The event processor to be used</typeparam>
        public void AddProcessor<T>() where T : IEventProcessor
        {
            _eventProcessors.Add(typeof(T));
        }

        /// <summary>
        /// Sets which directory to use as active journal directory
        /// </summary>
        public void UseJournalDirectory(string path)
        {
            _journalDirectory = path;
        }

        /// <summary>
        /// Sets which journal file to use, defaults to latest if not invoked
        /// </summary>
        public void UseJournal(string journal)
        {
            _journal = journal;
        }

        internal void AddServices(IServiceCollection services)
        {
            foreach (var implementation in _eventModuleImplementations) services.AddSingleton(implementation);

            foreach (var implementation in _eventProcessors)
                services.AddSingleton(typeof(IEventProcessor), implementation);

            services.AddSingleton<IEliteDangerousApiConfiguration>(Build());
        }

        private EliteDangerousApiConfiguration Build()
        {
            return new() { JournalPath = _journalDirectory, Journal = _journal };
        }
    }
}