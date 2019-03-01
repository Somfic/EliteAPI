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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; internal set; }
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
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
