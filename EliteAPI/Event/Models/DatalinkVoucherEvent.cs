using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class DatalinkVoucherEvent : EventBase
    {
        internal DatalinkVoucherEvent() { }
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }

        [JsonProperty("PayeeFaction")]
        public string PayeeFaction { get; internal set; }

        
    }
}