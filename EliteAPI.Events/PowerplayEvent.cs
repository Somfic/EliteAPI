using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct PowerplayEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Power")]
    public string Power { get; init; }

    [JsonProperty("Rank")]
    public long Rank { get; init; }

    [JsonProperty("Merits")]
    public long Merits { get; init; }

    [JsonProperty("Votes")]
    public long Votes { get; init; }

    [JsonProperty("TimePledged")]
    public long TimePledged { get; init; }
}