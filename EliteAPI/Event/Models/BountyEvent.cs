using System.Collections.Generic;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class BountyEvent : EventBase
    {
        internal BountyEvent() { }

        public static BountyEvent FromJson(string json) => JsonConvert.DeserializeObject<BountyEvent>(json);


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

        
    }
}