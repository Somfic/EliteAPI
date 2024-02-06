using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct HullDamageEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Health")]
    public double Health { get; init; }

    [JsonProperty("PlayerPilot")]
    public bool IsPlayerPilot { get; init; }

    [JsonProperty("Fighter")]
    public bool IsFighter { get; init; }
}