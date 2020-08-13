using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class BuyExplorationDataEvent : EventBase
    {
        internal BuyExplorationDataEvent() { }
        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        
    }
}