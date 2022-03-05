using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct LaunchSrvEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Loadout")]
    public string Loadout { get; init; }

    [JsonProperty("ID")]
    public string Id { get; init; }

    [JsonProperty("PlayerControlled")]
    public bool IsPlayerControlled { get; init; }
}