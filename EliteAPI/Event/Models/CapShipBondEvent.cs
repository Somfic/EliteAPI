using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CapShipBondEvent : EventBase
    {
        internal CapShipBondEvent() { }

        public static CapShipBondEvent FromJson(string json) => JsonConvert.DeserializeObject<CapShipBondEvent>(json);

        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        [JsonProperty("RewardingFaction")]
        public string RewardingFaction { get; internal set; }


        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }
        
    }
}