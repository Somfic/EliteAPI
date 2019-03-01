namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class AsteroidCrackedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }
    }

    public partial class AsteroidCrackedInfo
    {
        public static AsteroidCrackedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeAsteroidCrackedEvent(JsonConvert.DeserializeObject<AsteroidCrackedInfo>(json, EliteAPI.Events.AsteroidCrackedConverter.Settings));
    }

    public static class AsteroidCrackedSerializer
    {
        public static string ToJson(this AsteroidCrackedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.AsteroidCrackedConverter.Settings);
    }

    internal static class AsteroidCrackedConverter
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
