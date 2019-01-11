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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Interdictor")]
        public string Interdictor { get; set; }

        [JsonProperty("Interdictor_Localised")]
        public string InterdictorLocalised { get; set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; set; }
    }

    public partial class EscapeInterdictionInfo
    {
        public static EscapeInterdictionInfo Process(string json) => EventHandler.InvokeEscapeInterdictionEvent(JsonConvert.DeserializeObject<EscapeInterdictionInfo>(json, EliteAPI.Events.EscapeInterdictionConverter.Settings));
    }

    public static class EscapeInterdictionSerializer
    {
        public static string ToJson(this EscapeInterdictionInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.EscapeInterdictionConverter.Settings);
    }

    internal static class EscapeInterdictionConverter
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
