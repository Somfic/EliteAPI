using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct RestockVehicleEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Type")]
    public string Type { get; init; }

    [JsonProperty("Loadout")]
    public string Loadout { get; init; }

    [JsonProperty("Cost")]
    public long Cost { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }
}