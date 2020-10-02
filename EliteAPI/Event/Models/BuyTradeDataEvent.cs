using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class BuyTradeDataEvent : EventBase
    {
        internal BuyTradeDataEvent() { }

        public static BuyTradeDataEvent FromJson(string json) => JsonConvert.DeserializeObject<BuyTradeDataEvent>(json);


        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        
    }
}