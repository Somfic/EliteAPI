using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class RepairEvent : EventBase
    {
        internal RepairEvent() { }

        public static RepairEvent FromJson(string json) => JsonConvert.DeserializeObject<RepairEvent>(json);


        [JsonProperty("Item")]
        public string Item { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        
    }
}