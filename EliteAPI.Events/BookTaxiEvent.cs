using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct BookTaxiEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Cost")]
    public long Cost { get; init; }

    [JsonProperty("DestinationSystem")]
    public string DestinationSystem { get; init; }

    [JsonProperty("DestinationLocation")]
    public string DestinationLocation { get; init; }
    
    [JsonProperty("Retreat")]
    public bool IsRetreat { get; init; }
}