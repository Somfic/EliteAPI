using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class HeatDamageInfo : IEvent
    {
        internal static HeatDamageInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeHeatDamageEvent(JsonConvert.DeserializeObject<HeatDamageInfo>(json, EliteAPI.Events.HeatDamageConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
}
