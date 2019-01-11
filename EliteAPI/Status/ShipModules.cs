namespace EliteAPI.Status
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ShipModules
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Modules")]
        public List<Module> Modules { get; set; }
    }

    public partial class Module
    {
        [JsonProperty("Slot")]
        public string Slot { get; set; }

        [JsonProperty("Item")]
        public string Item { get; set; }

        [JsonProperty("Power")]
        public double Power { get; set; }

        [JsonProperty("Priority", NullValueHandling = NullValueHandling.Ignore)]
        public long? Priority { get; set; }
    }

    public partial class ShipModules
    {
        public static ShipModules FromJson(string json) => JsonConvert.DeserializeObject<ShipModules>(json, EliteAPI.Status.ShipModulesConverter.Settings);
    }

    public static class ShipModulesSerializer
    {
        public static string ToJson(this ShipModules self) => JsonConvert.SerializeObject(self, EliteAPI.Status.ShipModulesConverter.Settings);
    }

    internal static class ShipModulesConverter
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
