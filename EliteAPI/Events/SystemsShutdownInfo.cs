using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SystemsShutdownInfo : IEvent
    {
        internal static SystemsShutdownInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSystemsShutdownEvent(JsonConvert.DeserializeObject<SystemsShutdownInfo>(json, EliteAPI.Events.SystemsShutdownConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
}
