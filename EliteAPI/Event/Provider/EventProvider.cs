using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Provider.Abstractions;
using EliteAPI.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Event.Provider
{
    /// <inheritdoc />
    public class EventProvider : IEventProvider
    {
        private readonly Assembly _assembly;
        private readonly ILogger<EventProvider> _log;

        private IDictionary<string, Type> _cache;

        public EventProvider(IServiceProvider service)
        {
            _log = service.GetRequiredService<ILogger<EventProvider>>();
            _assembly = Assembly.GetExecutingAssembly();
        }

        /// <inheritdoc />
        public Task<EventBase> ProcessJsonEvent(string json)
        {
            if (_cache == null) RegisterEventClasses();

            try
            {
                var parsedFromGame = JsonConvert.DeserializeObject<JObject>(json);
                string eventName = ((dynamic) parsedFromGame).@event;

                var method = GetFromJsonMethod(eventName);
                var eventBase = InvokeFromJsonMethod(method, json);

                _log.LogTrace(json);

                return Task.FromResult(eventBase);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Json", json);

                _log.LogTrace(ex, "Could not convert json to EventBase");

                throw;
            }
        }

        /// <inheritdoc />
        public Task RegisterEventClasses()
        {
            _cache = new ConcurrentDictionary<string, Type>();

            foreach (var eventType in GetAllEventTypes(typeof(EventHandler)))
                _cache.Add(eventType.Name.Replace("Event", "").ToUpper(), eventType);

            return Task.CompletedTask;
        }

        private IEnumerable<Type> GetAllEventTypes(Type eventHandler)
        {
            var eventTypes = _assembly.GetTypes()
                .Where(x => x.IsSubclassOf(typeof(EventBase)) && x.IsClass && !x.IsAbstract);

            return eventTypes;
        }

        private MethodBase GetFromJsonMethod(string eventName)
        {
            try
            {
                var type = _cache[eventName.ToUpper()];

                return type.GetMethods().First(x => x.Name == "FromJson");
            }
            catch (Exception ex)
            {
                throw new EventNotImplementedException($"The {eventName} is not implemented", ex);
            }
           
        }

        private EventBase InvokeFromJsonMethod(MethodBase method, string json)
        {
            return method.Invoke(null, new object[] {json}) as EventBase;
        }
    }
}