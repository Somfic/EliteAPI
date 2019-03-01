namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DockingDeniedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Reason")]
        public string Reason { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }
    }

    public partial class DockingDeniedInfo
    {
        public static DockingDeniedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockingDeniedEvent(JsonConvert.DeserializeObject<DockingDeniedInfo>(json, EliteAPI.Events.DockingDeniedConverter.Settings));
    }

    public static class DockingDeniedSerializer
    {
        public static string ToJson(this DockingDeniedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DockingDeniedConverter.Settings);
    }

    internal static class DockingDeniedConverter
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
