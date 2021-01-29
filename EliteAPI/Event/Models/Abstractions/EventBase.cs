using System;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Abstractions
{
    /// <summary>
    /// An in-game event
    /// </summary>
    public abstract class EventBase : IEvent
    {
        /// <inheritdoc />
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; protected set; } = DateTime.Now;

        /// <inheritdoc />
        [JsonProperty("event")]
        public string Event { get; protected set; }
    }
}