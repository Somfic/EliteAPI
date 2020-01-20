using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DatalinkVoucherInfo : IEvent
    {
        internal static DatalinkVoucherInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDatalinkVoucherEvent(JsonConvert.DeserializeObject<DatalinkVoucherInfo>(json, EliteAPI.Events.DatalinkVoucherConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }
        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }
        [JsonProperty("PayeeFaction")]
        public string PayeeFaction { get; internal set; }
    }
}
