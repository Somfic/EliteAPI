using System.Collections.Generic;
using EliteAPI.Event.Models.Travel;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class RedeemVoucherEvent : EventBase
    {
        internal RedeemVoucherEvent() { }

        public static RedeemVoucherEvent FromJson(string json) => JsonConvert.DeserializeObject<RedeemVoucherEvent>(json);


        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("Factions")]
        public List<FSDJumpFaction> Factions { get; internal set; }

        
    }
}