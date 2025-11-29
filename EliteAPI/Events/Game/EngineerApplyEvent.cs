using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct EngineerApplyEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Engineer")]
    public string Engineer { get; init; }

    [JsonProperty("Blueprint")]
    public string Blueprlong { get; init; }

    [JsonProperty("Level")]
    public long Level { get; init; }
}
