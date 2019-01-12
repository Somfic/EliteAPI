namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DockFighterInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
    }

    public partial class DockFighterInfo
    {
        public static DockFighterInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockFighterEvent(JsonConvert.DeserializeObject<DockFighterInfo>(json, EliteAPI.Events.DockFighterConverter.Settings));
    }

    public static class DockFighterSerializer
    {
        public static string ToJson(this DockFighterInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DockFighterConverter.Settings);
    }

    internal static class DockFighterConverter
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
