using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ScreenshotEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Filename")]
    public string Filename { get; init; }

    [JsonProperty("Width")]
    public long Width { get; init; }

    [JsonProperty("Height")]
    public long Height { get; init; }

    [JsonProperty("System")]
    public string System { get; init; }

    [JsonProperty("Body")]
    public string Body { get; init; }
}