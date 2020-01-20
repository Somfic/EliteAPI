using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EngineerApplyInfo : EventBase
    {
        internal static EngineerApplyInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEngineerApplyEvent(JsonConvert.DeserializeObject<EngineerApplyInfo>(json, JsonSettings.Settings));

        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }
        [JsonProperty("Blueprint")]
        public string Blueprint { get; internal set; }
        [JsonProperty("Level")]
        public long Level { get; internal set; }
        [JsonProperty("Override")]
        public string Override { get; internal set; }
    }
}
