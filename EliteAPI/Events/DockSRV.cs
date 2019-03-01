namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DockSRVInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }
    }

    public partial class DockSRVInfo
    {
        public static DockSRVInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockSRVEvent(JsonConvert.DeserializeObject<DockSRVInfo>(json, EliteAPI.Events.DockSRVConverter.Settings));
    }

    public static class DockSRVSerializer
    {
        public static string ToJson(this DockSRVInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DockSRVConverter.Settings);
    }

    internal static class DockSRVConverter
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
