using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CapShipBondEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Reward")]
    public long Reward { get; init; }

    [JsonProperty("RewardingFaction")]
    public string RewardingFaction { get; init; }

    [JsonProperty("VictimFaction")]
    public string VictimFaction { get; init; }

    [JsonProperty("AwardingFaction")]
    public string AwardingFaction { get; init; }
}
