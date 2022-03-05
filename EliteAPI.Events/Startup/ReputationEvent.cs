using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ReputationEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Empire")]
    public double Empire { get; init; }

    [JsonProperty("Federation")]
    public double Federation { get; init; }

    [JsonProperty("Independent")]
    public double Independent { get; init; }

    [JsonProperty("Alliance")]
    public double Alliance { get; init; }
}