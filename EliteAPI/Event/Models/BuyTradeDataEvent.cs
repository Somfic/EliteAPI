using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class BuyTradeDataEvent : EventBase
    {
        internal BuyTradeDataEvent() { }
        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        
    }
}