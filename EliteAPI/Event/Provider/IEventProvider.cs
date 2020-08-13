using System;
using System.Threading.Tasks;
using EliteAPI.Event.Models;

namespace EliteAPI.Event.Provider
{
    /// <summary>
    /// Converts JSON events to <see cref="EventBase"/> events
    /// </summary>
    public interface IEventProvider
    {
        /// <summary>
        /// Fired when a new event is detected
        /// </summary>
        EventHandler<EventBase> JournalEvent { get; }

        /// <summary>
        /// Processes a JSON event to <see cref="EventBase"/> and invokes the <see cref="JournalEvent"/> handler
        /// </summary>
        /// <param name="json"></param>
        Task ProcessJsonEvent(string json);
    }
}