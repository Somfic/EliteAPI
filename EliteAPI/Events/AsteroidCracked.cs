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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Body")]
        public string Body { get; set; }
    }

    public partial class AsteroidCrackedInfo
    {
        public static AsteroidCrackedInfo Process(string json) => EventHandler.InvokeAsteroidCrackedEvent(JsonConvert.DeserializeObject<AsteroidCrackedInfo>(json, EliteAPI.Events.AsteroidCrackedConverter.Settings));
    }

    public static class AsteroidCrackedSerializer
    {
        public static string ToJson(this AsteroidCrackedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.AsteroidCrackedConverter.Settings);
    }

    internal static class AsteroidCrackedConverter
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
