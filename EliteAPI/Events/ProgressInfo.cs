using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ProgressInfo : EventBase
    {
        internal static ProgressInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeProgressEvent(JsonConvert.DeserializeObject<ProgressInfo>(json, JsonSettings.Settings));

        [JsonProperty("Combat")]
        public long Combat { get; internal set; }
        [JsonProperty("Trade")]
        public long Trade { get; internal set; }
        [JsonProperty("Explore")]
        public long Explore { get; internal set; }
        [JsonProperty("Empire")]
        public long Empire { get; internal set; }
        [JsonProperty("Federation")]
        public long Federation { get; internal set; }
        [JsonProperty("CQC")]
        public long Cqc { get; internal set; }
    }
}
