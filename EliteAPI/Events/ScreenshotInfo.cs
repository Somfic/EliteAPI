using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ScreenshotInfo : IEvent
    {
        internal static ScreenshotInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeScreenshotEvent(JsonConvert.DeserializeObject<ScreenshotInfo>(json, EliteAPI.Events.ScreenshotConverter.Settings));

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
}
