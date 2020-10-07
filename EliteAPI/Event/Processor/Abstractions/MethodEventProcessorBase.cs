using EliteAPI.Event.Models.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace EliteAPI.Event.Processor.Abstractions
{
    public abstract class MethodEventProcessorBase : IEventProcessor
    {
        private readonly ILogger _log;
        private readonly IServiceProvider _services;

        /// <summary>
        /// Methods to invoke, mapped to the name of a event
        /// </summary>
        protected IDictionary<string, IEnumerable<MethodBase>> Cache { get; set; }

        protected MethodEventProcessorBase(ILogger log, IServiceProvider services)
        {
            _log = log;
            _services = services;
        }

        public abstract Task RegisterHandlers();

        /// <inheritdoc />
        public async Task InvokeHandler(EventBase eventBase)
        {
            if (Cache == null) { await RegisterHandlers(); }

            try
            {
                string key = eventBase.GetType().Name;

                if (!Cache.ContainsKey(key)) { return; }

                IEnumerable<MethodBase> methods = Cache[key];

                foreach (MethodBase method in methods)
                {
                    InvokeMethod(method, eventBase);
                }
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
                Type parentClass = method.DeclaringType;
                if (parentClass == null)
                {
                    ArgumentNullException ex = new ArgumentNullException(nameof(method.DeclaringType));
                    _log.LogTrace(ex, "Could not invoke for {event} event, DeclaringType was null");
                    return;
                }

                string methodName = $"{parentClass.FullName}:{method.Name}";
                object parentClassInstance = _services.GetRequiredService(parentClass);

                _log.LogDebug("Invoking {method} for {event} event", methodName, eventBase.Event);

                method.Invoke(parentClassInstance, new object[] {eventBase});
            }
            catch (InvalidOperationException ex)
            {
                _log.LogWarning(ex, "{parentClass} is not registered", method.DeclaringType?.FullName);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Could not invoke method for {event}", eventBase.Event);
            }
        }
    }
}