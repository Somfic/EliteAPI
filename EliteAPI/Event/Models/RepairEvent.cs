using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class RepairEvent : EventBase
    {
        internal RepairEvent() { }
        [JsonProperty("Item")]
        public string Item { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        
    }
}