using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MarketBuyInfo : EventBase
    {
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

        internal static MarketBuyInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMarketBuyEvent(JsonConvert.DeserializeObject<MarketBuyInfo>(json, JsonSettings.Settings));
        }
    }
}