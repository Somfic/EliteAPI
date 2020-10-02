using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class TouchdownEvent : EventBase
    {
        internal TouchdownEvent() { }

        public static TouchdownEvent FromJson(string json) => JsonConvert.DeserializeObject<TouchdownEvent>(json);


        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        [JsonProperty("Latitude")]
        public float Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public float Longitude { get; internal set; }

        
    }
}