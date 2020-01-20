using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class RebootRepairInfo : EventBase
    {
        internal static RebootRepairInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRebootRepairEvent(JsonConvert.DeserializeObject<RebootRepairInfo>(json, JsonSettings.Settings));

        [JsonProperty("Modules")]
        public List<string> Modules { get; internal set; }
    }
}
