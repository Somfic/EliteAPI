using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RepairAllInfo : EventBase
    {
        internal static RepairAllInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRepairAllEvent(JsonConvert.DeserializeObject<RepairAllInfo>(json, JsonSettings.Settings));

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }
}
