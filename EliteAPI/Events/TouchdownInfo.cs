using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TouchdownInfo : IEvent
    {
        internal static TouchdownInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeTouchdownEvent(JsonConvert.DeserializeObject<TouchdownInfo>(json, JsonSettings.Settings));

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
}