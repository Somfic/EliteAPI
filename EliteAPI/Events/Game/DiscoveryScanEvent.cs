using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct DiscoveryScanEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("Bodies")]
    public long Bodies { get; init; }
}
