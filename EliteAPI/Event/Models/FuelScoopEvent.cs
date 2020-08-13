using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FuelScoopEvent : EventBase
    {
        internal FuelScoopEvent() { }
        [JsonProperty("Scooped")]
        public float Scooped { get; internal set; }

        [JsonProperty("Total")]
        public float Total { get; internal set; }

        
    }
}