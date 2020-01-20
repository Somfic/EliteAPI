using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class AsteroidCrackedInfo : IEvent
    {
        internal static AsteroidCrackedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeAsteroidCrackedEvent(JsonConvert.DeserializeObject<AsteroidCrackedInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Body")]
        public string Body { get; internal set; }
    }
}
