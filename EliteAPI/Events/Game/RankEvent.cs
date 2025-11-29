using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct RankEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Combat")]
    public long Combat { get; init; }

    [JsonProperty("Trade")]
    public long Trade { get; init; }

    [JsonProperty("Explore")]
    public long Explore { get; init; }

    [JsonProperty("Empire")]
    public long Empire { get; init; }

    [JsonProperty("Federation")]
    public long Federation { get; init; }

    [JsonProperty("Soldier")]
    public long Soldier { get; init; }

    [JsonProperty("Exobiologist")]
    public long Exobiologist { get; init; }

    [JsonProperty("CQC")]
    public long Cqc { get; init; }
}
