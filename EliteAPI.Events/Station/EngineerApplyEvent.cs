using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct EngineerApplyEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Engineer")]
    public string Engineer { get; init; }

    [JsonProperty("Blueprint")]
    public string Blueprint { get; init; }

    [JsonProperty("Level")]
    public long Level { get; init; }
}