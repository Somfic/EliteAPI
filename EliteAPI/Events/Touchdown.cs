namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TouchdownInfo
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

    public partial class TouchdownInfo
    {
        public static TouchdownInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeTouchdownEvent(JsonConvert.DeserializeObject<TouchdownInfo>(json, EliteAPI.Events.TouchdownConverter.Settings));
    }

    public static class TouchdownSerializer
    {
        public static string ToJson(this TouchdownInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.TouchdownConverter.Settings);
    }

    internal static class TouchdownConverter
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
