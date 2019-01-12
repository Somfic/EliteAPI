namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CockpitBreachedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
    }

    public partial class CockpitBreachedInfo
    {
        public static CockpitBreachedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCockpitBreachedEvent(JsonConvert.DeserializeObject<CockpitBreachedInfo>(json, EliteAPI.Events.CockpitBreachedConverter.Settings));
    }

    public static class CockpitBreachedSerializer
    {
        public static string ToJson(this CockpitBreachedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CockpitBreachedConverter.Settings);
    }

    internal static class CockpitBreachedConverter
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
