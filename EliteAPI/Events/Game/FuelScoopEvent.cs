using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct FuelScoopEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Scooped")]
    public double Scooped { get; init; }

    [JsonProperty("Total")]
    public double Total { get; init; }
}
