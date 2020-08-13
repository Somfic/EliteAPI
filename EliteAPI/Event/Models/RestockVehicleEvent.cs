using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class RestockVehicleEvent : EventBase
    {
        internal RestockVehicleEvent() { }
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        
    }
}