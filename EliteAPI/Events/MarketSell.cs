namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MarketSellInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; set; }

        [JsonProperty("TotalSale")]
        public long TotalSale { get; set; }

        [JsonProperty("AvgPricePaid")]
        public long AvgPricePaid { get; set; }

        [JsonProperty("StolenGoods")]
        public bool StolenGoods { get; set; }

        [JsonProperty("BlackMarket")]
        public bool BlackMarket { get; set; }
    }

    public partial class MarketSellInfo
    {
        public static MarketSellInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMarketSellEvent(JsonConvert.DeserializeObject<MarketSellInfo>(json, EliteAPI.Events.MarketSellConverter.Settings));
    }

    public static class MarketSellSerializer
    {
        public static string ToJson(this MarketSellInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MarketSellConverter.Settings);
    }

    internal static class MarketSellConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
