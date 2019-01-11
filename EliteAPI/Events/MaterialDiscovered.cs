namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MaterialDiscoveredInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; set; }

        [JsonProperty("DiscoveryNumber")]
        public long DiscoveryNumber { get; set; }
    }

    public partial class MaterialDiscoveredInfo
    {
        public static MaterialDiscoveredInfo Process(string json) => EventHandler.InvokeMaterialDiscoveredEvent(JsonConvert.DeserializeObject<MaterialDiscoveredInfo>(json, EliteAPI.Events.MaterialDiscoveredConverter.Settings));
    }

    public static class MaterialDiscoveredSerializer
    {
        public static string ToJson(this MaterialDiscoveredInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MaterialDiscoveredConverter.Settings);
    }

    internal static class MaterialDiscoveredConverter
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
