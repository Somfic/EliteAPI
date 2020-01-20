using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class BuyExplorationDataInfo : EventBase
    {
        internal static BuyExplorationDataInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeBuyExplorationDataEvent(JsonConvert.DeserializeObject<BuyExplorationDataInfo>(json, JsonSettings.Settings));

        [JsonProperty("System")]
        public string System { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }
}
