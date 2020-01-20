using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RepairInfo : IEvent
    {
        internal static RepairInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRepairEvent(JsonConvert.DeserializeObject<RepairInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Item")]
        public string Item { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }
}
