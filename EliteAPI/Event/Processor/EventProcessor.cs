using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EliteAPI.Event.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EventHandler = EliteAPI.Event.Handler.EventHandler;

namespace EliteAPI.Event.Processor
{
    /// <inheritdoc />
    public class EventProcessor : IEventProcessor
    {
        private readonly Assembly _assembly; 

        private IDictionary<string, IEnumerable<MethodBase>> _cache;
        private ILogger<EventProcessor> _log;

        public EventProcessor(IServiceProvider services)
        {
            _assembly = Assembly.GetExecutingAssembly();
            _log = services.GetRequiredService<ILogger<EventProcessor>>();
        }

        /// <inheritdoc />q
        public Task RegisterHandlers()
        {
            try
            {
                _log.LogDebug("Detecting event handlers");
                Stopwatch s = Stopwatch.StartNew();

                _cache = new ConcurrentDictionary<string, IEnumerable<MethodBase>>();

                var eventHandler = typeof(EventHandler);

                var eventTypes = GetAllEventTypes(eventHandler).ToList();
                var invokeMethods = GetAllInvokeMethods(eventHandler).ToList();

                _log.LogTrace("Found {methodCount} events", invokeMethods.Count);

                int totalHandlers = 0;

                foreach (var eventType in eventTypes)
                {
                    var validMethods = GetAllInvokeMethodsForEvent(invokeMethods, eventType.Name).ToList();

                    if (!validMethods.Any())
                    {
                        _log.LogTrace("No invoke methods could be found for {eventNameSpace}", eventType.FullName);
                    }
                    else
                    {
                        totalHandlers += validMethods.Count;
                        _log.LogTrace("Registering {methodCount} methods for {eventName} to cache at {eventNameSpace}",
                            validMethods.Count, eventType.Name, validMethods.Select(x => $"{x.DeclaringType?.FullName}.{x.Name}"));
                        _cache.Add(eventType.Name, validMethods);
                    }
                }

                s.Stop();
                _log.LogDebug("{eventCount} event-handlers were registered in {time}ms", totalHandlers, s.ElapsedMilliseconds);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _log.LogTrace(ex, "Could not register event handlers");
                throw;
            }
        }

        /// <inheritdoc />
        public Task InvokeHandler<T>(EventBase @event) where T : EventBase
        {
            if (_cache == null) { RegisterHandlers(); }

            return Task.CompletedTask;
        }

        private IEnumerable<Type> GetAllEventTypes(Type eventHandler)
        {
            var eventTypes = _assembly.GetTypes()
                .Where(x => x.IsSubclassOf(typeof(EventBase)) && x.IsClass && !x.IsAbstract);

            return eventTypes;
        }

        private IEnumerable<MethodBase> GetAllInvokeMethods(Type eventHandler)
        {
            return eventHandler.GetMethods(BindingFlags.Instance 
                                           | BindingFlags.NonPublic 
                                           | BindingFlags.Public 
                                           | BindingFlags.Static)
                .Where(MethodIsValidInvokeMethod);
        }

        private IEnumerable<MethodBase> GetAllInvokeMethodsForEvent(IEnumerable<MethodBase> methods, string eventName)
        {
            return methods.Where(x => eventName.StartsWith(x.GetParameters().First().ParameterType.Name));
        }

        private bool MethodIsValidInvokeMethod(MethodBase method)
        {
            return !method.Name.StartsWith("add_")
                   && !method.Name.StartsWith("remove_")
                   && method.GetParameters().Length > 0
                   && method.GetParameters().First().ParameterType.IsSubclassOf(typeof(EventBase));
        }
    }
}