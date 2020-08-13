using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class RefuelAllEvent : EventBase
    {
        internal RefuelAllEvent() { }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("Amount")]
        public float Amount { get; internal set; }

        
    }
}