using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class DiscoveryScanEvent : EventBase
    {
        internal DiscoveryScanEvent() { }
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Bodies")]
        public long Bodies { get; internal set; }

        
    }
}