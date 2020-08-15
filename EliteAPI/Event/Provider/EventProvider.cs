using System;
using System.Threading.Tasks;
using EliteAPI.Event.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EliteAPI.Event.Provider
{
    /// <inheritdoc />
    public class EventProvider : IEventProvider
    {
        private readonly ILogger<EventProvider> _log;

        public EventProvider(IServiceProvider service)
        {
            _log = service.GetRequiredService<ILogger<EventProvider>>();
        }

        /// <inheritdoc />
        public Task<EventBase> ProcessJsonEvent(string json)
        {
            try
            {
                return Task.FromResult(JsonConvert.DeserializeObject<EventBase>(json));
            }
            catch (Exception ex)
            {
                ex.Data.Add("Json", json);

                _log.LogTrace(ex,"Could not convert json to EventBase");

                throw;
            }
        }
    }
}