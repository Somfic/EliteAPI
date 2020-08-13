using System;
using System.Threading.Tasks;
using EliteAPI.Event.Models;

namespace EliteAPI.Event.Provider
{
    /// <inheritdoc />
    public class EventProvider : IEventProvider
    {
        /// <inheritdoc />
        public EventHandler<EventBase> JournalEvent { get; }

        /// <inheritdoc />
        public Task ProcessJsonEvent(string json)
        {
            throw new NotImplementedException();
        }
    }
}