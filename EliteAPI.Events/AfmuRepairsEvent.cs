using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct AfmuRepairsEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Module")]
    public Localised Module { get; init; }

    [JsonProperty("FullyRepaired")]
    public bool IsFullyRepaired { get; init; }

    [JsonProperty("Health")]
    public double Health { get; init; }
}