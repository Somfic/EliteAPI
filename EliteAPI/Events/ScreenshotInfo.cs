using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ScreenshotInfo : EventBase
    {
        internal static ScreenshotInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeScreenshotEvent(JsonConvert.DeserializeObject<ScreenshotInfo>(json, JsonSettings.Settings));

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
