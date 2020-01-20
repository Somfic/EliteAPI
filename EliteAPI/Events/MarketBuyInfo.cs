using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MarketBuyInfo : EventBase
    {
        internal static MarketBuyInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMarketBuyEvent(JsonConvert.DeserializeObject<MarketBuyInfo>(json, JsonSettings.Settings));

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
