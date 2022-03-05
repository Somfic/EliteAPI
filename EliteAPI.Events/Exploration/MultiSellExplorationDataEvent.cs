using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct MultiSellExplorationDataEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Discovered")]
    public IReadOnlyCollection<Discovered> Discovered { get; init; }

    [JsonProperty("BaseValue")]
    public long BaseValue { get; init; }

    [JsonProperty("Bonus")]
    public long Bonus { get; init; }

    [JsonProperty("TotalEarnings")]
    public long TotalEarnings { get; init; }
}

public readonly struct Discovered
{
    [JsonProperty("SystemName")]
    public string SystemName { get; init; }

    [JsonProperty("NumBodies")]
    public long NumBodies { get; init; }
}