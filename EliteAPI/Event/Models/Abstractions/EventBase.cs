using System;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Abstractions
{
    /// <inheritdoc />
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