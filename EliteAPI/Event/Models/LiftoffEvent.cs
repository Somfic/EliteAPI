using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class LiftoffEvent : EventBase
    {
        internal LiftoffEvent() { }
        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        [JsonProperty("Latitude")]
        public float Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public float Longitude { get; internal set; }

        
    }
}