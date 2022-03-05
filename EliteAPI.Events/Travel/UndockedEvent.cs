using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct UndockedEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("StationName")]
    public string StationName { get; init; }

    [JsonProperty("StationType")]
    public string StationType { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("Taxi")]
    public bool IsTaxi { get; init; }

    [JsonProperty("Multicrew")]
    public bool IsMulticrew { get; init; }
}