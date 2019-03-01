namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ScreenshotInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Filename")]
        public string Filename { get; internal set; }

        [JsonProperty("Width")]
        public long Width { get; internal set; }

        [JsonProperty("Height")]
        public long Height { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; internal set; }

        [JsonProperty("Heading")]
        public long Heading { get; internal set; }

        [JsonProperty("Altitude")]
        public double Altitude { get; internal set; }
    }

    public partial class ScreenshotInfo
    {
        public static ScreenshotInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeScreenshotEvent(JsonConvert.DeserializeObject<ScreenshotInfo>(json, EliteAPI.Events.ScreenshotConverter.Settings));
    }

    public static class ScreenshotSerializer
    {
        public static string ToJson(this ScreenshotInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ScreenshotConverter.Settings);
    }

    internal static class ScreenshotConverter
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
