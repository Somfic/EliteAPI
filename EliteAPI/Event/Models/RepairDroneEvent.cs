using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class RepairDroneEvent : EventBase
    {
        internal RepairDroneEvent() { }
        [JsonProperty("HullRepaired")]
        public float HullRepaired { get; internal set; }

        [JsonProperty("CockpitRepaired")]
        public float CockpitRepaired { get; internal set; }

        
    }
}