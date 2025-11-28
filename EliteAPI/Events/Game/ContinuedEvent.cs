using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ContinuedEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Part")]
    public long Part { get; init; }
}
