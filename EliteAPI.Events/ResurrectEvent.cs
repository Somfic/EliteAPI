using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ResurrectEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Option")]
    public string Option { get; init; }

    [JsonProperty("Cost")]
    public long Cost { get; init; }

    [JsonProperty("Bankrupt")]
    public bool IsBankrupt { get; init; }
}