using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events.Status.Cargo;

public readonly struct CargoEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Vessel")]
    public string Vessel { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }

    [JsonProperty("Inventory")]
    public IReadOnlyCollection<CargoItem> Inventory { get; init; }
}