using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class DiscoveryScanEvent : EventBase
    {
        internal DiscoveryScanEvent() { }

        public static DiscoveryScanEvent FromJson(string json) => JsonConvert.DeserializeObject<DiscoveryScanEvent>(json);


        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; internal set; }

        [JsonProperty("Bodies")]
        public long Bodies { get; internal set; }

        
    }
}