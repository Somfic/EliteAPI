using System;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    /// <summary>
    /// The interface every event implements.
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// The timestamp of the event.
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// The name of the event.
        /// </summary>
        string Event { get;  }
    }

    /// <summary>
    /// Wrapper for all events.
    /// </summary>
    public abstract class EventBase : IEvent
    {
        /// <summary>
        /// The timestamp of the event.
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; protected set; }

        /// <summary>
        /// The name of the event.
        /// </summary>
        [JsonProperty("event")]
        public string Event { get; protected set; }
    }
}