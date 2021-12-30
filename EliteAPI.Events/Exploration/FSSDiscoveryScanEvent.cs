using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

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
}