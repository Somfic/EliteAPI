using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct AfmuRepairsEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Module")]
    public LocalisedField Module { get; init; }

    [JsonProperty("FullyRepaired")]
    public bool IsFullyRepaired { get; init; }

    [JsonProperty("Health")]
    public double Health { get; init; }
}
