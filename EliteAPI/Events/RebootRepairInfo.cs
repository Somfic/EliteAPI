using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class RebootRepairInfo : IEvent
    {
        internal static RebootRepairInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRebootRepairEvent(JsonConvert.DeserializeObject<RebootRepairInfo>(json, EliteAPI.Events.RebootRepairConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Modules")]
        public List<string> Modules { get; internal set; }
    }
}
