using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct FssAllBodiesFoundEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("SystemName")]
    public string SystemName { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }
}
