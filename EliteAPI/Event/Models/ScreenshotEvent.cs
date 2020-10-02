using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ScreenshotEvent : EventBase
    {
        internal ScreenshotEvent() { }

        public static ScreenshotEvent FromJson(string json) => JsonConvert.DeserializeObject<ScreenshotEvent>(json);


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
        public float Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public float Longitude { get; internal set; }

        [JsonProperty("Heading")]
        public long Heading { get; internal set; }

        [JsonProperty("Altitude")]
        public float Altitude { get; internal set; }

        
    }
}