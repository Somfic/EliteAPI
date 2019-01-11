namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MarketBuyInfo
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

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; set; }

        [JsonProperty("TotalCost")]
        public long TotalCost { get; set; }
    }

    public partial class MarketBuyInfo
    {
        public static MarketBuyInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeMarketBuyEvent(JsonConvert.DeserializeObject<MarketBuyInfo>(json, EliteAPI.Events.MarketBuyConverter.Settings));
    }

    public static class MarketBuySerializer
    {
        public static string ToJson(this MarketBuyInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MarketBuyConverter.Settings);
    }

    internal static class MarketBuyConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
