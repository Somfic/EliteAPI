using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FSSDiscoveryScanEvent : EventBase
    {
        internal FSSDiscoveryScanEvent() { }
        [JsonProperty("Progress")]
        public float Progress { get; internal set; }

        [JsonProperty("BodyCount")]
        public long BodyCount { get; internal set; }

        [JsonProperty("NonBodyCount")]
        public long NonBodyCount { get; internal set; }

        
    }
}