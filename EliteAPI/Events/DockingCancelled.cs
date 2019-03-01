namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DockingCancelledInfo
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

    public partial class DockingCancelledInfo
    {
        public static DockingCancelledInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockingCancelledEvent(JsonConvert.DeserializeObject<DockingCancelledInfo>(json, EliteAPI.Events.DockingCancelledConverter.Settings));
    }

    public static class DockingCancelledSerializer
    {
        public static string ToJson(this DockingCancelledInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DockingCancelledConverter.Settings);
    }

    internal static class DockingCancelledConverter
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
