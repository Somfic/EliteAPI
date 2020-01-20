using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FactionKillBondInfo : EventBase
    {
        internal static FactionKillBondInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFactionKillBondEvent(JsonConvert.DeserializeObject<FactionKillBondInfo>(json, JsonSettings.Settings));

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
