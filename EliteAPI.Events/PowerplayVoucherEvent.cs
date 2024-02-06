using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct PowerplayVoucherEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Power")]
    public string Power { get; init; }

    [JsonProperty("Systems")]
    public IReadOnlyCollection<string> Systems { get; init; }
}