namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ShipyardTransferInfo
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

        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("ShipMarketID")]
        public long ShipMarketId { get; internal set; }

        [JsonProperty("Distance")]
        public double Distance { get; internal set; }

        [JsonProperty("TransferPrice")]
        public long TransferPrice { get; internal set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
    }

    public partial class ShipyardTransferInfo
    {
        public static ShipyardTransferInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShipyardTransferEvent(JsonConvert.DeserializeObject<ShipyardTransferInfo>(json, EliteAPI.Events.ShipyardTransferConverter.Settings));
    }

    public static class ShipyardTransferSerializer
    {
        public static string ToJson(this ShipyardTransferInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ShipyardTransferConverter.Settings);
    }

    internal static class ShipyardTransferConverter
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
