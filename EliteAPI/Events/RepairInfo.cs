using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RepairInfo : EventBase
    {
        internal static RepairInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRepairEvent(JsonConvert.DeserializeObject<RepairInfo>(json, JsonSettings.Settings));

        [JsonProperty("Item")]
        public string Item { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }
}
