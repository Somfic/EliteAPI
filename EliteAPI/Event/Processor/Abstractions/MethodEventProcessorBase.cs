using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Processor.Abstractions
{
    public abstract class MethodEventProcessorBase : IEventProcessor
    {
        private readonly ILogger _log;
        private readonly IServiceProvider _services;

        protected MethodEventProcessorBase(ILogger log, IServiceProvider services)
        {
            _log = log;
            _services = services;
        }

        /// <summary>
        ///     Methods to invoke, mapped to the name of a event
        /// </summary>
        protected IDictionary<string, IEnumerable<MethodBase>> Cache { get; set; }

        /// <inheritdoc />
        public abstract Task RegisterHandlers();

        /// <inheritdoc />
        public async Task InvokeHandler(EventBase eventBase, bool isWhileCatchingUp)
        {
            if (Cache == null) await RegisterHandlers();

            try
            {
                var key = eventBase.GetType().Name;

                if (!Cache.ContainsKey(key)) return;

                var methods = Cache[key];

                foreach (var method in methods) InvokeMethod(method, eventBase);
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not invoke methods for {eventName}", eventBase.Event);
            }
        }

        private void InvokeMethod(MethodBase method, IEvent eventBase)
        {
            try
            {
                var parentClass = method.DeclaringType;
                if (parentClass == null)
                {
                    var ex = new ArgumentNullException(nameof(method.DeclaringType));
                    _log.LogTrace(ex, "Could not invoke for {event} event, DeclaringType was null");
                    return;
                }

                var methodName = $"{parentClass.FullName}:{method.Name}";
                var parentClassInstance = _services.GetRequiredService(parentClass);

                if (method.DeclaringType.Namespace.StartsWith("EliteAPI"))
                    _log.LogTrace("Invoking {method} for {event} event", methodName, eventBase.Event);
                else
                    _log.LogDebug("Invoking {method} for {event} event", methodName, eventBase.Event);

                method.Invoke(parentClassInstance, new object[] {eventBase});
            }
            catch (InvalidOperationException ex)
            {
                _log.LogWarning(ex, "{parentClass} is not registered", method.DeclaringType?.FullName);
            }
        }
    }
}