namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class StoredModulesInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("Items")]
        public List<StoredModuleItem> Items { get; set; }
    }

    public partial class StoredModuleItem
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; set; }

        [JsonProperty("StorageSlot")]
        public long StorageSlot { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("TransferCost")]
        public long TransferCost { get; set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; set; }

        [JsonProperty("Hot")]
        public bool Hot { get; set; }

        [JsonProperty("EngineerModifications", NullValueHandling = NullValueHandling.Ignore)]
        public string EngineerModifications { get; set; }

        [JsonProperty("Level", NullValueHandling = NullValueHandling.Ignore)]
        public long? Level { get; set; }

        [JsonProperty("Quality", NullValueHandling = NullValueHandling.Ignore)]
        public double? Quality { get; set; }
    }

    public partial class StoredModulesInfo
    {
        public static StoredModulesInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeStoredModulesEvent(JsonConvert.DeserializeObject<StoredModulesInfo>(json, EliteAPI.Events.StoredModulesConverter.Settings));
    }

    public static class StoredModulesSerializer
    {
        public static string ToJson(this StoredModulesInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.StoredModulesConverter.Settings);
    }

    internal static class StoredModulesConverter
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
