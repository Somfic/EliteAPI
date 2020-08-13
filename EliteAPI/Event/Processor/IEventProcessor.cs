using System.Threading.Tasks;
using EliteAPI.Event.Models;

namespace EliteAPI.Event.Processor
{
    /// <summary>
    /// Invokes registered event-handlers
    /// </summary>
    public interface IEventProcessor
    {
        /// <summary>
        /// Finds, registers, and caches the event-handlers
        /// </summary>
        /// <returns></returns>
        Task RegisterHandlers();

        /// <summary>
        /// Invokes the registered handler for this event
        /// </summary>
        /// <typeparam name="T">The type of event</typeparam>
        /// <param name="event">The event to be invoked</param>
        Task InvokeHandler<T>(EventBase @event) where T : EventBase;
    }
}
