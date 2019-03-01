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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("DiscoveryNumber")]
        public long DiscoveryNumber { get; internal set; }
    }

    public partial class MaterialDiscoveredInfo
    {
        public static MaterialDiscoveredInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialDiscoveredEvent(JsonConvert.DeserializeObject<MaterialDiscoveredInfo>(json, EliteAPI.Events.MaterialDiscoveredConverter.Settings));
    }

    public static class MaterialDiscoveredSerializer
    {
        public static string ToJson(this MaterialDiscoveredInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MaterialDiscoveredConverter.Settings);
    }

    internal static class MaterialDiscoveredConverter
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
