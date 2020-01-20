using System;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public interface IEvent
    {

    }

    public abstract class EventBase : EventBase
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; protected set; }
        [JsonProperty("event")]
        public string Event { get; protected set; }
    }
}