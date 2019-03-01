namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FSSDiscoveryScanInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Progress")]
        public double Progress { get; internal set; }

        [JsonProperty("BodyCount")]
        public long BodyCount { get; internal set; }

        [JsonProperty("NonBodyCount")]
        public long NonBodyCount { get; internal set; }
    }

    public partial class FSSDiscoveryScanInfo
    {
        public static FSSDiscoveryScanInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFSSDiscoveryScanEvent(JsonConvert.DeserializeObject<FSSDiscoveryScanInfo>(json, EliteAPI.Events.FSSDiscoveryScanConverter.Settings));
    }

    public static class FSSDiscoveryScanSerializer
    {
        public static string ToJson(this FSSDiscoveryScanInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FSSDiscoveryScanConverter.Settings);
    }

    internal static class FSSDiscoveryScanConverter
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
