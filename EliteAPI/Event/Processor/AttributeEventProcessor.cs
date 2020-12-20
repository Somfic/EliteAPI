using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EliteAPI.Event.Attributes;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Module;
using EliteAPI.Event.Processor.Abstractions;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Event.Processor
{
    /// <inheritdoc />
    public class AttributeEventProcessor : MethodEventProcessorBase
    {
        private readonly Assembly _assembly;

        private readonly ILogger<AttributeEventProcessor> _log;
        private readonly Assembly _thirdPartyAssembly;

        public AttributeEventProcessor(ILogger<AttributeEventProcessor> log, IServiceProvider services) : base(log,
            services)
        {
            _assembly = Assembly.GetExecutingAssembly();
            _thirdPartyAssembly = Assembly.GetEntryAssembly();
            _log = log;
        }

        /// <inheritdoc />
        public override Task RegisterHandlers()
        {
            try
            {
                _log.LogDebug("Detecting event handlers");
                var s = Stopwatch.StartNew();

                Cache = new ConcurrentDictionary<string, IEnumerable<MethodBase>>();
                var allEvents = GetAllEventTypes();
                var allMethods = GetAllValidMethods();


                var totalHandlers = 0;

                foreach (var eventType in allEvents)
                {
                    var validMethods = GetAllValidMethodsForEvent(allMethods, eventType).ToList();

                    if (validMethods.Any())
                    {
                        totalHandlers += validMethods.Count;
                        _log.LogTrace("Registering {eventName} to {eventNameSpace}",
                            eventType.Name, validMethods.Select(x => $"{x.DeclaringType?.FullName}.{x.Name}"));
                        Cache.Add(eventType.Name, validMethods);
                    }
                }

                s.Stop();
                _log.LogDebug("{eventCount} event-handlers were registered in {time}ms", totalHandlers,
                    s.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                _log.LogTrace(ex, "Could not register event handlers");
                throw;
            }

            return Task.CompletedTask;
        }

        private IEnumerable<Type> GetAllEventTypes()
        {
            var eventTypes = _assembly.GetTypes()
                .Where(x => x.IsSubclassOf(typeof(EventBase)) && x.IsClass && !x.IsAbstract);

            return eventTypes;
        }

        private IEnumerable<MethodBase> GetAllValidMethods()
        {
            return _thirdPartyAssembly
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(EliteDangerousEventModule)))
                .SelectMany(x => x.GetMethods()
                    .Where(y =>
                        y.GetCustomAttribute<EliteDangerousEventAttribute>() != null
                        && y.GetParameters().Length == 1
                        && y.GetParameters()[0].ParameterType.IsSubclassOf(typeof(EventBase))
                    ));
        }

        private IEnumerable<MethodBase> GetAllValidMethodsForEvent(IEnumerable<MethodBase> methods, Type eventToCompare)
        {
            return methods.Where(x => x.GetParameters()[0].ParameterType == eventToCompare);
        }
    }
}