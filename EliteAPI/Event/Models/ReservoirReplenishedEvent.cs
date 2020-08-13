using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ReservoirReplenishedEvent : EventBase
    {
        internal ReservoirReplenishedEvent() { }
        [JsonProperty("FuelMain")]
        public float FuelMain { get; set; }

        [JsonProperty("FuelReservoir")]
        public float FuelReservoir { get; set; }

        
    }
}