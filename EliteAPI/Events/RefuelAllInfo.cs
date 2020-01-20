using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RefuelAllInfo : EventBase
    {
        internal static RefuelAllInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRefuelAllEvent(JsonConvert.DeserializeObject<RefuelAllInfo>(json, JsonSettings.Settings));

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
        [JsonProperty("Amount")]
        public double Amount { get; internal set; }
    }
}
