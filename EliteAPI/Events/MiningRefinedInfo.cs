using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MiningRefinedInfo : EventBase
    {
        internal static MiningRefinedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMiningRefinedEvent(JsonConvert.DeserializeObject<MiningRefinedInfo>(json, JsonSettings.Settings));

        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }
    }
}
