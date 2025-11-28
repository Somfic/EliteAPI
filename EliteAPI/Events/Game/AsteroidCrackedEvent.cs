using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct AsteroidCrackedEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Body")]
    public string Body { get; init; }
}
