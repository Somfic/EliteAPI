using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct RefuelAllEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Cost")]
    public long Cost { get; init; }

    [JsonProperty("Amount")]
    public double Amount { get; init; }
}
