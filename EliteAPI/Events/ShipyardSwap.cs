namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ShipyardSwapInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("StoreOldShip")]
        public string StoreOldShip { get; internal set; }

        [JsonProperty("StoreShipID")]
        public long StoreShipId { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
    }

    public partial class ShipyardSwapInfo
    {
        public static ShipyardSwapInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShipyardSwapEvent(JsonConvert.DeserializeObject<ShipyardSwapInfo>(json, EliteAPI.Events.ShipyardSwapConverter.Settings));
    }

    public static class ShipyardSwapSerializer
    {
        public static string ToJson(this ShipyardSwapInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ShipyardSwapConverter.Settings);
    }

    internal static class ShipyardSwapConverter
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
