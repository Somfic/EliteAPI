using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RepairAllInfo : IEvent
    {
        internal static RepairAllInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRepairAllEvent(JsonConvert.DeserializeObject<RepairAllInfo>(json, EliteAPI.Events.RepairAllConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }
}
