using System;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Abstractions
{
    /// <summary>
    /// An in-game event
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// The timestamp of the event
        /// </summary>
        [JsonProperty("timestamp")]
        DateTime Timestamp { get; }

        /// <summary>
        /// The name of the event
        /// </summary>
        [JsonProperty("event")]
        string Event { get; }
    }
}