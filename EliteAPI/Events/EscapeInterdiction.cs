namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class EscapeInterdictionInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Interdictor")]
        public string Interdictor { get; internal set; }

        [JsonProperty("Interdictor_Localised")]
        public string InterdictorLocalised { get; internal set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }
    }

    public partial class EscapeInterdictionInfo
    {
        public static EscapeInterdictionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEscapeInterdictionEvent(JsonConvert.DeserializeObject<EscapeInterdictionInfo>(json, EliteAPI.Events.EscapeInterdictionConverter.Settings));
    }

    public static class EscapeInterdictionSerializer
    {
        public static string ToJson(this EscapeInterdictionInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.EscapeInterdictionConverter.Settings);
    }

    internal static class EscapeInterdictionConverter
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
