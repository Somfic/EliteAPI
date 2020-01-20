using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class AsteroidCrackedInfo : EventBase
    {
        internal static AsteroidCrackedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeAsteroidCrackedEvent(JsonConvert.DeserializeObject<AsteroidCrackedInfo>(json, JsonSettings.Settings));

        [JsonProperty("Body")]
        public string Body { get; internal set; }
    }
}
