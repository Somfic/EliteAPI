using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct PowerplayVoteEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Power")]
    public string Power { get; init; }

    [JsonProperty("Votes")]
    public long Votes { get; init; }

    [JsonProperty("")]
    public long Empty { get; init; }
}