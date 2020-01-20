using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class HeatWarningInfo : IEvent
    {
        internal static HeatWarningInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeHeatWarningEvent(JsonConvert.DeserializeObject<HeatWarningInfo>(json, EliteAPI.Events.HeatWarningConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
}
