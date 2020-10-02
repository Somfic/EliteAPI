using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class RepairAllEvent : EventBase
    {
        internal RepairAllEvent() { }

        public static RepairAllEvent FromJson(string json) => JsonConvert.DeserializeObject<RepairAllEvent>(json);


        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        
    }
}