namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class StoredShipsInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("ShipsHere")]
        public List<object> ShipsHere { get; internal set; }

        [JsonProperty("ShipsRemote")]
        public List<ShipsRemote> ShipsRemote { get; internal set; }
    }

    public partial class ShipsRemote
    {
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("ShipMarketID")]
        public long ShipMarketId { get; internal set; }

        [JsonProperty("TransferPrice")]
        public long TransferPrice { get; internal set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; internal set; }

        [JsonProperty("Value")]
        public long Value { get; internal set; }

        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }

        [JsonProperty("ShipType_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; internal set; }
    }

    public partial class StoredShipsInfo
    {
        public static StoredShipsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeStoredShipsEvent(JsonConvert.DeserializeObject<StoredShipsInfo>(json, EliteAPI.Events.StoredShipsConverter.Settings));
    }

    public static class StoredShipsSerializer
    {
        public static string ToJson(this StoredShipsInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.StoredShipsConverter.Settings);
    }

    internal static class StoredShipsConverter
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
