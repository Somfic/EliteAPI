using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct FsdTargetEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("StarClass")]
    public string StarClass { get; init; }

    [JsonProperty("RemainingJumpsInRoute")]
    public int RemainingJumpsInRoute { get; init; }
}