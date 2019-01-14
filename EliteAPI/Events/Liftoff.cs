namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class LiftoffInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; set; }
    }

    public partial class LiftoffInfo
    {
        public static LiftoffInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLiftoffEvent(JsonConvert.DeserializeObject<LiftoffInfo>(json, EliteAPI.Events.LiftoffConverter.Settings));
    }

    public static class LiftoffSerializer
    {
        public static string ToJson(this LiftoffInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.LiftoffConverter.Settings);
    }

    internal static class LiftoffConverter
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
