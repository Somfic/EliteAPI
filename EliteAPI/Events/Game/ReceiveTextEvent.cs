using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ReceiveTextEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("From")]
    public LocalisedField From { get; init; }

    [JsonProperty("Message")]
    public LocalisedField Message { get; init; }

    [JsonProperty("Channel")]
    public string Channel { get; init; }
}
