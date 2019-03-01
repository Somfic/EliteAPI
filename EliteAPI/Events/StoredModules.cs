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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("Items")]
        public List<StoredModuleItem> Items { get; internal set; }
    }

    public partial class StoredModuleItem
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("StorageSlot")]
        public long StorageSlot { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("TransferCost")]
        public long TransferCost { get; internal set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; internal set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; internal set; }

        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }

        [JsonProperty("EngineerModifications", NullValueHandling = NullValueHandling.Ignore)]
        public string EngineerModifications { get; internal set; }

        [JsonProperty("Level", NullValueHandling = NullValueHandling.Ignore)]
        public long? Level { get; internal set; }

        [JsonProperty("Quality", NullValueHandling = NullValueHandling.Ignore)]
        public double? Quality { get; internal set; }
    }

    public partial class StoredModulesInfo
    {
        public static StoredModulesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeStoredModulesEvent(JsonConvert.DeserializeObject<StoredModulesInfo>(json, EliteAPI.Events.StoredModulesConverter.Settings));
    }

    public static class StoredModulesSerializer
    {
        public static string ToJson(this StoredModulesInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.StoredModulesConverter.Settings);
    }

    internal static class StoredModulesConverter
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
