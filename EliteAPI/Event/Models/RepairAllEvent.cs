using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class RepairAllEvent : EventBase
    {
        internal RepairAllEvent() { }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        
    }
}