using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct SellExplorationDataEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Systems")]
    public IReadOnlyCollection<string> Systems { get; init; }

    [JsonProperty("Discovered")]
    public IReadOnlyCollection<string> Discovered { get; init; }

    [JsonProperty("BaseValue")]
    public long BaseValue { get; init; }

    [JsonProperty("Bonus")]
    public long Bonus { get; init; }
}