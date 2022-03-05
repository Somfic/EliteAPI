using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ReceiveTextEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("From")]
    public Localised From { get; init; }

    [JsonProperty("Message")]
    public Localised Message { get; init; }

    [JsonProperty("Channel")]
    public string Channel { get; init; }
}