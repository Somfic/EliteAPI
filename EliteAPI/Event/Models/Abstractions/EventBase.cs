using System;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Abstractions
{
    /// <inheritdoc />
    public abstract class EventBase : IEvent
    {
        /// <inheritdoc />
        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; protected set; } = DateTime.Now;

        /// <inheritdoc />
        [JsonProperty("Event")]
        public string Event { get; protected set; }
    }
}