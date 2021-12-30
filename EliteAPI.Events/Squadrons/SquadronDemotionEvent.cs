using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct SquadronDemotionEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("SquadronName")]
    public string Name { get; init; }

    [JsonProperty("OldRank")]
    public int OldRank { get; init; }

    [JsonProperty("NewRank")]
    public int NewRank { get; init; }
}