using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct UssDropEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("USSType")]
    public Localised USSType { get; init; }

    [JsonProperty("USSThreat")]
    public long UssThreat { get; init; }
}