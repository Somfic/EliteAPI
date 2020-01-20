using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DatalinkVoucherInfo : EventBase
    {
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }

        [JsonProperty("PayeeFaction")]
        public string PayeeFaction { get; internal set; }

        internal static DatalinkVoucherInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDatalinkVoucherEvent(JsonConvert.DeserializeObject<DatalinkVoucherInfo>(json, JsonSettings.Settings));
        }
    }
}