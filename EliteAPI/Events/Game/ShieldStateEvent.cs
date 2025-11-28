using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ShieldStateEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("ShieldsUp")]
    public bool IsShieldsUp { get; init; }
}
