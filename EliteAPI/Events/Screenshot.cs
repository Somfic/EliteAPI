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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Filename")]
        public string Filename { get; set; }

        [JsonProperty("Width")]
        public long Width { get; set; }

        [JsonProperty("Height")]
        public long Height { get; set; }

        [JsonProperty("System")]
        public string System { get; set; }

        [JsonProperty("Body")]
        public string Body { get; set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; set; }

        [JsonProperty("Heading")]
        public long Heading { get; set; }

        [JsonProperty("Altitude")]
        public double Altitude { get; set; }
    }

    public partial class ScreenshotInfo
    {
        public static ScreenshotInfo Process(string json) => EventHandler.InvokeScreenshotEvent(JsonConvert.DeserializeObject<ScreenshotInfo>(json, EliteAPI.Events.ScreenshotConverter.Settings));
    }

    public static class ScreenshotSerializer
    {
        public static string ToJson(this ScreenshotInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ScreenshotConverter.Settings);
    }

    internal static class ScreenshotConverter
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
