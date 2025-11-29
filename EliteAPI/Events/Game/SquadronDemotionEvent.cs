using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct SquadronDemotionEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("SquadronName")]
    public string Name { get; init; }

    [JsonProperty("OldRank")]
    public long OldRank { get; init; }

    [JsonProperty("NewRank")]
    public long NewRank { get; init; }
}
