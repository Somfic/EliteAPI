using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DatalinkVoucherInfo : EventBase
    {
        internal static DatalinkVoucherInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDatalinkVoucherEvent(JsonConvert.DeserializeObject<DatalinkVoucherInfo>(json, JsonSettings.Settings));

        [JsonProperty("Reward")]
        public long Reward { get; internal set; }
        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }
        [JsonProperty("PayeeFaction")]
        public string PayeeFaction { get; internal set; }
    }
}
