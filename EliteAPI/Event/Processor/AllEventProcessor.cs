using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Processor.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EventHandler = EliteAPI.Event.Handler.EventHandler;

namespace EliteAPI.Event.Processor
{
    class AllEventProcessor : IEventProcessor
    {
        private readonly ILogger<AllEventProcessor> _log;
        private MethodBase _invokeMethod;
        private EventHandler _eventHandler;

        public AllEventProcessor(ILogger<AllEventProcessor> log, IServiceProvider services)
        {
            _log = log;
            _eventHandler = services.GetRequiredService<EventHandler>();
        }

        public Task RegisterHandlers()
        {
            return Task.CompletedTask;
        }

        public Task InvokeHandler(EventBase eventBase, bool isWhileCatchingUp)
        {
            try
            {
                _log.LogTrace("Invoking AllEvent for {event}", eventBase.Event);
                _eventHandler.InvokeAllEvent(eventBase);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Could not invoke method for {event}", eventBase.Event);
                return Task.CompletedTask;
            }
        }
    }
}
