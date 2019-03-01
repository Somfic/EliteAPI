namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DiscoveryScanInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Bodies")]
        public long Bodies { get; internal set; }
    }

    public partial class DiscoveryScanInfo
    {
        public static DiscoveryScanInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDiscoveryScanEvent(JsonConvert.DeserializeObject<DiscoveryScanInfo>(json, EliteAPI.Events.DiscoveryScanConverter.Settings));
    }

    public static class DiscoveryScanSerializer
    {
        public static string ToJson(this DiscoveryScanInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DiscoveryScanConverter.Settings);
    }

    internal static class DiscoveryScanConverter
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
