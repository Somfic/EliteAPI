namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MassModuleStoreInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("Ship")]
        public string Ship { get; set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; set; }

        [JsonProperty("Items")]
        public List<Item> Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("Slot")]
        public string Slot { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; set; }

        [JsonProperty("Hot")]
        public bool Hot { get; set; }

        [JsonProperty("EngineerModifications")]
        public string EngineerModifications { get; set; }

        [JsonProperty("Level")]
        public long Level { get; set; }

        [JsonProperty("Quality")]
        public double Quality { get; set; }
    }

    public partial class MassModuleStoreInfo
    {
        public static MassModuleStoreInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMassModuleStoreEvent(JsonConvert.DeserializeObject<MassModuleStoreInfo>(json, EliteAPI.Events.MassModuleStoreConverter.Settings));
    }

    public static class MassModuleStoreSerializer
    {
        public static string ToJson(this MassModuleStoreInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MassModuleStoreConverter.Settings);
    }

    internal static class MassModuleStoreConverter
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
