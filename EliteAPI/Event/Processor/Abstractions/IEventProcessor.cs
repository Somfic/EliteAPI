using System.Threading.Tasks;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Processor.Abstractions
{
    /// <summary>
    ///     Invokes registered event-handlers
    /// </summary>
    public interface IEventProcessor
    {
        /// <summary>
        ///     Finds, registers, and caches the event-handlers
        /// </summary>
        /// <returns></returns>
        Task RegisterHandlers();

        /// <summary>
        ///     Invokes the registered handler for this event
        /// </summary>
        /// <param name="eventBase">The event to be invoked</param>
        /// <param name="isWhileCatchingUp">Whether this event was ran before EliteAPI was started</param>
        Task InvokeHandler(EventBase eventBase, bool isWhileCatchingUp);
    }
}