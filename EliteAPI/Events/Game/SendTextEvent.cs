using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct SendTextEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("To")]
    public string To { get; init; }

    [JsonProperty("Message")]
    public string Message { get; init; }

    [JsonProperty("Sent")]
    public bool IsSent { get; init; }
}
