namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class QuitACrewInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Captain")]
        public string Captain { get; internal set; }
    }

    public partial class QuitACrewInfo
    {
        public static QuitACrewInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeQuitACrewEvent(JsonConvert.DeserializeObject<QuitACrewInfo>(json, EliteAPI.Events.QuitACrewConverter.Settings));
    }

    public static class QuitACrewSerializer
    {
        public static string ToJson(this QuitACrewInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.QuitACrewConverter.Settings);
    }

    internal static class QuitACrewConverter
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
