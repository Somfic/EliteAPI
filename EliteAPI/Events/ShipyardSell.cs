namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ShipyardSellInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("ShipType")]
        public string ShipType { get; set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; set; }

        [JsonProperty("SellShipID")]
        public long SellShipId { get; set; }

        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }
    }

    public partial class ShipyardSellInfo
    {
        public static ShipyardSellInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShipyardSellEvent(JsonConvert.DeserializeObject<ShipyardSellInfo>(json, EliteAPI.Events.ShipyardSellConverter.Settings));
    }

    public static class ShipyardSellSerializer
    {
        public static string ToJson(this ShipyardSellInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ShipyardSellConverter.Settings);
    }

    internal static class ShipyardSellConverter
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
