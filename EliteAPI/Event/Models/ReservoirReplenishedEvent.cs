using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ReservoirReplenishedEvent : EventBase
    {
        internal ReservoirReplenishedEvent() { }

        public static ReservoirReplenishedEvent FromJson(string json) => JsonConvert.DeserializeObject<ReservoirReplenishedEvent>(json);


        [JsonProperty("FuelMain")]
        public float FuelMain { get; set; }

        [JsonProperty("FuelReservoir")]
        public float FuelReservoir { get; set; }

        
    }
}