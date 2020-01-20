using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FactionKillBondInfo : IEvent
    {
        internal static FactionKillBondInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFactionKillBondEvent(JsonConvert.DeserializeObject<FactionKillBondInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
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
