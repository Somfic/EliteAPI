namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class InterdictionInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Success")]
        public bool Success { get; set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; set; }

        [JsonProperty("Interdicted")]
        public string Interdicted { get; set; }

        [JsonProperty("Faction")]
        public string Faction { get; set; }

        [JsonProperty("Power")]
        public string Power { get; set; }
    }

    public partial class InterdictionInfo
    {
        public static InterdictionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeInterdictionEvent(JsonConvert.DeserializeObject<InterdictionInfo>(json, EliteAPI.Events.InterdictionConverter.Settings));
    }

    public static class InterdictionSerializer
    {
        public static string ToJson(this InterdictionInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.InterdictionConverter.Settings);
    }

    internal static class InterdictionConverter
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
