using EliteAPI.Event.Handler;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Processor.Abstractions;

namespace EliteAPI.Event.Processor
{
    internal class AllEventProcessor : IEventProcessor
    {
        private readonly EventHandler _eventHandler;
        private readonly ILogger<AllEventProcessor> _log;
        private MethodBase _invokeMethod;

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