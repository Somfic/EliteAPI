namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DockingRequestedInfo
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

    public partial class DockingRequestedInfo
    {
        public static DockingRequestedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockingRequestedEvent(JsonConvert.DeserializeObject<DockingRequestedInfo>(json, EliteAPI.Events.DockingRequestedConverter.Settings));
    }

    public static class DockingRequestedSerializer
    {
        public static string ToJson(this DockingRequestedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DockingRequestedConverter.Settings);
    }

    internal static class DockingRequestedConverter
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
