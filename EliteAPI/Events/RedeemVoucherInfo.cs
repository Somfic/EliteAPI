using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class RedeemVoucherInfo : EventBase
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("Factions")]
        public List<FSDFaction> Factions { get; internal set; }

        internal static RedeemVoucherInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeRedeemVoucherEvent(JsonConvert.DeserializeObject<RedeemVoucherInfo>(json, JsonSettings.Settings));
        }
    }
}