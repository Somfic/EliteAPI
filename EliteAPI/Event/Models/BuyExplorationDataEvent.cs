using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class BuyExplorationDataEvent : EventBase
    {
        internal BuyExplorationDataEvent() { }

        public static BuyExplorationDataEvent FromJson(string json) => JsonConvert.DeserializeObject<BuyExplorationDataEvent>(json);


        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        
    }
}