using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MaterialTradeEvent : EventBase
    {
        internal MaterialTradeEvent() { }

        public static MaterialTradeEvent FromJson(string json) => JsonConvert.DeserializeObject<MaterialTradeEvent>(json);


        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("TraderType")]
        public string TraderType { get; internal set; }

        [JsonProperty("Paid")]
        public Paid Paid { get; internal set; }

        [JsonProperty("Received")]
        public Paid Received { get; internal set; }

        
    }
}