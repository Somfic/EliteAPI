using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Provider.Abstractions;
using EliteAPI.Exceptions;
using EliteAPI.Services.Variables;
using FluentAssertions;
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
        private readonly VariablesService _variables;

        private IDictionary<string, Type> _cache;

        public EventProvider(ILogger<EventProvider> log, VariablesService variables)
        {
            _log = log;
            _variables = variables;
            _assembly = Assembly.GetExecutingAssembly();
        }

        /// <inheritdoc />
        public Task<IEvent> ProcessJsonEvent(string json)
        {
            if (_cache == null) RegisterEventClasses();

            JObject parsedFromGame = null;
            string eventName = null;

            try
            {
                _log.LogTrace(json);

                parsedFromGame = JsonConvert.DeserializeObject<JObject>(json);
                eventName = ((dynamic) parsedFromGame).@event;

                var method = GetFromJsonMethod(eventName);
                var gameEvent = InvokeFromJsonMethod(method, json);
                //var parsedEliteApiEvents = JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(gameEvent, new JsonSerializerSettings {ContractResolver = new JsonContractResolver()}));
                var parsedEliteApiEvents = JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(gameEvent));


                var gameVariables = _variables.GetVariables(parsedFromGame);
                var gamePaths = gameVariables.Select(x => x.Name).ToList();
                
                var eliteApiPaths = _variables.GetVariables(parsedEliteApiEvents).Select(x => x.Name).ToList();

                var missing = gamePaths.Except(eliteApiPaths).ToList();
                if (missing.Any())
                {
                    _log.LogWarning("{Name} event misses: {Missing}", eventName, string.Join(", " , gameVariables.Where(x => missing.Contains(x.Name)).Select(y => $"{y.Name} ({y.Type})")));
                }


                return Task.FromResult(gameEvent);
            }
            catch (EventNotImplementedException ex)
            {
                ex.Data.Add("Json", json);

                _log.LogDebug(ex, "{Event} event not yet implemented", eventName);
                return Task.FromResult(new NotImplementedEvent(json, parsedFromGame) as IEvent);
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
                .Where(x => typeof(IEvent).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract && !x.IsInterface);

            return eventTypes;
        }

        private MethodBase GetFromJsonMethod(string eventName)
        {
            try
            {
                if (!_cache.ContainsKey(eventName.ToUpper()))
                {
                    throw new EventNotImplementedException($"The {eventName} event is not implemented");
                }

                var type = _cache[eventName.ToUpper()];
                var method = type.BaseType
                    ?.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static |
                                 BindingFlags.Instance).First(x => x.Name == "FromJson");

                if (method == null)
                {
                    throw new NullReferenceException("The FromJson method could not be found");
                }

                return method;
            }
            catch (Exception ex)
            {
                throw new EventNotImplementedException($"The {eventName} event is not correctly implemented", ex);
            }
        }

        private IEvent InvokeFromJsonMethod(MethodBase method, string json)
        {
            return method.Invoke(null, new object[] {json}) as IEvent;
        }
    }
}