using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class RepairDroneEvent : EventBase
    {
        internal RepairDroneEvent() { }

        public static RepairDroneEvent FromJson(string json) => JsonConvert.DeserializeObject<RepairDroneEvent>(json);


        [JsonProperty("HullRepaired")]
        public float HullRepaired { get; internal set; }

        [JsonProperty("CockpitRepaired")]
        public float CockpitRepaired { get; internal set; }

        
    }
}