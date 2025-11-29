using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct PowerplaySalaryEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Power")]
    public string Power { get; init; }

    [JsonProperty("Amount")]
    public long Amount { get; init; }
}
