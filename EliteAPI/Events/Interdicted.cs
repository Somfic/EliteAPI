namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class InterdictedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Submitted")]
        public bool Submitted { get; set; }

        [JsonProperty("Interdictor")]
        public string Interdictor { get; set; }

        [JsonProperty("Interdictor_Localised")]
        public string InterdictorLocalised { get; set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; set; }

        [JsonProperty("Faction")]
        public string Faction { get; set; }
    }

    public partial class InterdictedInfo
    {
        public static InterdictedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeInterdictedEvent(JsonConvert.DeserializeObject<InterdictedInfo>(json, EliteAPI.Events.InterdictedConverter.Settings));
    }

    public static class InterdictedSerializer
    {
        public static string ToJson(this InterdictedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.InterdictedConverter.Settings);
    }

    internal static class InterdictedConverter
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
