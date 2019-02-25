namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MaterialDiscardedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }
    }

    public partial class MaterialDiscardedInfo
    {
        public static MaterialDiscardedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialDiscardedEvent(JsonConvert.DeserializeObject<MaterialDiscardedInfo>(json, EliteAPI.Events.MaterialDiscardedConverter.Settings));
    }

    public static class MaterialDiscardedSerializer
    {
        public static string ToJson(this MaterialDiscardedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MaterialDiscardedConverter.Settings);
    }

    internal static class MaterialDiscardedConverter
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
