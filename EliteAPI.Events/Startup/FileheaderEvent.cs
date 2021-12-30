using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct FileheaderEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("part")]
    public long Part { get; init; }

    [JsonProperty("language")]
    public string Language { get; init; }

    [JsonProperty("gameversion")]
    public string Gameversion { get; init; }

    [JsonProperty("build")]
    public string Build { get; init; }

    [JsonProperty("Odyssey")]
    public bool IsOdyssey { get; init; }
}