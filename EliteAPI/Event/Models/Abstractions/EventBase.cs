using System;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models.Abstractions
{
    /// <summary>
    /// An in-game event
    /// </summary>
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public abstract class EventBase : IEvent
    {
        /// <inheritdoc />
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; protected set; } = DateTime.Now;

        /// <inheritdoc />
        [JsonProperty("event")]
        public string Event { get; protected set; }
        
        /// <inheritdoc />
        public string Json { get; internal set; }
    }
}