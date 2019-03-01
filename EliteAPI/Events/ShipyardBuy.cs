namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ShipyardBuyInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; internal set; }

        [JsonProperty("StoreOldShip")]
        public string StoreOldShip { get; internal set; }

        [JsonProperty("StoreShipID")]
        public long StoreShipId { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
    }

    public partial class ShipyardBuyInfo
    {
        public static ShipyardBuyInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShipyardBuyEvent(JsonConvert.DeserializeObject<ShipyardBuyInfo>(json, EliteAPI.Events.ShipyardBuyConverter.Settings));
    }

    public static class ShipyardBuySerializer
    {
        public static string ToJson(this ShipyardBuyInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ShipyardBuyConverter.Settings);
    }

    internal static class ShipyardBuyConverter
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
