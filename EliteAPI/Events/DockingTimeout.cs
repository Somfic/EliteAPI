namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DockingTimeoutInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }
    }

    public partial class DockingTimeoutInfo
    {
        public static DockingTimeoutInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockingTimeoutEvent(JsonConvert.DeserializeObject<DockingTimeoutInfo>(json, EliteAPI.Events.DockingTimeoutConverter.Settings));
    }

    public static class DockingTimeoutSerializer
    {
        public static string ToJson(this DockingTimeoutInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DockingTimeoutConverter.Settings);
    }

    internal static class DockingTimeoutConverter
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
