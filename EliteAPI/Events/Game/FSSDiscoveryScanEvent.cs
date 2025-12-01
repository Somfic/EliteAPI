using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct FssDiscoveryScanEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Progress")]
    public double Progress { get; init; }

    [JsonProperty("BodyCount")]
    public long BodyCount { get; init; }

    [JsonProperty("NonBodyCount")]
    public long NonBodyCount { get; init; }

    [JsonProperty("SystemName")]
    public string SystemName { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }
}
