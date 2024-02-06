using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct BountyEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Rewards")]
    public IReadOnlyCollection<BountyRewardInfo> Rewards { get; init; }

    [JsonProperty("Target")]
    public Localised Target { get; init; }

    [JsonProperty("TotalReward")]
    public long TotalReward { get; init; }

    [JsonProperty("VictimFaction")]
    public string VictimFaction { get; init; }

    [JsonProperty("SharedWithOthers")]
    public long SharedWithOthers { get; init; }

    [JsonProperty("Faction")]
    public string Faction { get; init; }
    
    
    [JsonProperty("Reward")]
    public long Reward { get; init; }

    public readonly struct BountyRewardInfo
    {
        [JsonProperty("Faction")]
        public string Faction { get; init; }

        [JsonProperty("Reward")]
        public long Reward { get; init; }
    }
}