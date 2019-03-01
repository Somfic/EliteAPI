namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DockingGrantedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("LandingPad")]
        public long LandingPad { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }
    }

    public partial class DockingGrantedInfo
    {
        public static DockingGrantedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockingGrantedEvent(JsonConvert.DeserializeObject<DockingGrantedInfo>(json, EliteAPI.Events.DockingGrantedConverter.Settings));
    }

    public static class DockingGrantedSerializer
    {
        public static string ToJson(this DockingGrantedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DockingGrantedConverter.Settings);
    }

    internal static class DockingGrantedConverter
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
