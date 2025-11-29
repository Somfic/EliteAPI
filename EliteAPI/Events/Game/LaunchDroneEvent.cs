using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct LaunchDroneEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Type")]
    public string Type { get; init; }
}
