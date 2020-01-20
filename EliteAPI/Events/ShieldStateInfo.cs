using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ShieldStateInfo : IEvent
    {
        internal static ShieldStateInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShieldStateEvent(JsonConvert.DeserializeObject<ShieldStateInfo>(json, EliteAPI.Events.ShieldStateConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("ShieldsUp")]
        public bool ShieldsUp { get; internal set; }
    }
}
