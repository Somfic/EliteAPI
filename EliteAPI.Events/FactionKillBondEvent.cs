using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct FactionKillBondEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Reward")]
    public long Reward { get; init; }

    [JsonProperty("AwardingFaction")]
    public string AwardingFaction { get; init; }

    [JsonProperty("VictimFaction")]
    public string VictimFaction { get; init; }
}