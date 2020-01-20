using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class RedeemVoucherInfo : EventBase
    {
        internal static RedeemVoucherInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRedeemVoucherEvent(JsonConvert.DeserializeObject<RedeemVoucherInfo>(json, JsonSettings.Settings));

        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }
        [JsonProperty("Factions")]
        public List<FSDFaction> Factions { get; internal set; }
    }
}