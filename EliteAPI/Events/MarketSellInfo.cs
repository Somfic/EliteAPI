using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MarketSellInfo : EventBase
    {
        internal static MarketSellInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMarketSellEvent(JsonConvert.DeserializeObject<MarketSellInfo>(json, JsonSettings.Settings));

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
        [JsonProperty("SellPrice")]
        public long SellPrice { get; internal set; }
        [JsonProperty("TotalSale")]
        public long TotalSale { get; internal set; }
        [JsonProperty("AvgPricePaid")]
        public long AvgPricePaid { get; internal set; }
        [JsonProperty("StolenGoods")]
        public bool StolenGoods { get; internal set; }
        [JsonProperty("BlackMarket")]
        public bool BlackMarket { get; internal set; }
    }
}
