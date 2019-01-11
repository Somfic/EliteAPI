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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("ShipsHere")]
        public List<object> ShipsHere { get; set; }

        [JsonProperty("ShipsRemote")]
        public List<ShipsRemote> ShipsRemote { get; set; }
    }

    public partial class ShipsRemote
    {
        [JsonProperty("ShipID")]
        public long ShipId { get; set; }

        [JsonProperty("ShipType")]
        public string ShipType { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("ShipMarketID")]
        public long ShipMarketId { get; set; }

        [JsonProperty("TransferPrice")]
        public long TransferPrice { get; set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; set; }

        [JsonProperty("Value")]
        public long Value { get; set; }

        [JsonProperty("Hot")]
        public bool Hot { get; set; }

        [JsonProperty("ShipType_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipTypeLocalised { get; set; }

        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class StoredShipsInfo
    {
        public static StoredShipsInfo Process(string json) => EventHandler.InvokeStoredShipsEvent(JsonConvert.DeserializeObject<StoredShipsInfo>(json, EliteAPI.Events.StoredShipsConverter.Settings));
    }

    public static class StoredShipsSerializer
    {
        public static string ToJson(this StoredShipsInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.StoredShipsConverter.Settings);
    }

    internal static class StoredShipsConverter
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
