using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CancelDropshipEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Refund")]
    public long Refund { get; init; }
}
