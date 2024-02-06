using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct InterdictionEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Success")]
    public bool IsSuccess { get; init; }

    [JsonProperty("IsPlayer")]
    public bool IsPlayer { get; init; }

    [JsonProperty("Faction")]
    public string Faction { get; init; }
}