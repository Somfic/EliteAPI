using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct UnderAttackEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Target")]
    public string Target { get; init; }
}
