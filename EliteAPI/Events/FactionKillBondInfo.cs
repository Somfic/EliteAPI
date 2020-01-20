using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FactionKillBondInfo : EventBase
    {
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

        internal static FactionKillBondInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeFactionKillBondEvent(JsonConvert.DeserializeObject<FactionKillBondInfo>(json, JsonSettings.Settings));
        }
    }
}