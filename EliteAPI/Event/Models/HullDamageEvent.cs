using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class HullDamageEvent : EventBase
    {
        internal HullDamageEvent() { }

        public static HullDamageEvent FromJson(string json) => JsonConvert.DeserializeObject<HullDamageEvent>(json);


        [JsonProperty("Health")]
        public float Health { get; internal set; }

        [JsonProperty("PlayerPilot")]
        public bool PlayerPilot { get; internal set; }

        [JsonProperty("Fighter")]
        public bool Fighter { get; internal set; }

        
    }
}