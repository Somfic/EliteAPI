using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct BookDropshipEvent : IEvent
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
