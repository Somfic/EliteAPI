using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class DatalinkVoucherEvent : EventBase
    {
        internal DatalinkVoucherEvent() { }

        public static DatalinkVoucherEvent FromJson(string json) => JsonConvert.DeserializeObject<DatalinkVoucherEvent>(json);


        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }

        [JsonProperty("PayeeFaction")]
        public string PayeeFaction { get; internal set; }

        
    }
}