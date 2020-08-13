using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class HullDamageEvent : EventBase
    {
        internal HullDamageEvent() { }
        [JsonProperty("Health")]
        public float Health { get; internal set; }

        [JsonProperty("PlayerPilot")]
        public bool PlayerPilot { get; internal set; }

        [JsonProperty("Fighter")]
        public bool Fighter { get; internal set; }

        
    }
}