using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MarketBuyEvent : EventBase
    {
        internal MarketBuyEvent() { }

        public static MarketBuyEvent FromJson(string json) => JsonConvert.DeserializeObject<MarketBuyEvent>(json);


        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; internal set; }

        [JsonProperty("TotalCost")]
        public long TotalCost { get; internal set; }

        
    }
}