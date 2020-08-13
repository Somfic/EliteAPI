using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ResurrectEvent : EventBase
    {
        internal ResurrectEvent() { }
        [JsonProperty("Option")]
        public string Option { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("Bankrupt")]
        public bool Bankrupt { get; internal set; }

        
    }
}