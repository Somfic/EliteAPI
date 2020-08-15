using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FactionKillBondEvent : EventBase
    {
        internal FactionKillBondEvent() { }
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        [JsonProperty("AwardingFaction")]
        public string AwardingFaction { get; internal set; }

        [JsonProperty("AwardingFaction_Localised")]
        public string AwardingFactionLocalised { get; internal set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }

        [JsonProperty("VictimFaction_Localised")]
        public string VictimFactionLocalised { get; internal set; }

        
    }
}