using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class BountyInfo : EventBase
    {
        [JsonProperty("Rewards")]
        public List<Reward> Rewards { get; internal set; }

        [JsonProperty("Target")]
        public string Target { get; internal set; }

        [JsonProperty("TotalReward")]
        public long TotalReward { get; internal set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }

        [JsonProperty("SharedWithOthers")]
        public long SharedWithOthers { get; internal set; }

        internal static BountyInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeBountyEvent(JsonConvert.DeserializeObject<BountyInfo>(json, JsonSettings.Settings));
        }
    }
}