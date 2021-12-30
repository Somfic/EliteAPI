using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CarrierModulePackEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("CarrierID")]
    public string CarrierId { get; init; }

    [JsonProperty("Operation")]
    public string Operation { get; init; }

    [JsonProperty("PackTheme")]
    public string Theme { get; init; }

    [JsonProperty("PackTier")]
    public int Tier { get; init; }

    [JsonProperty("Cost")]
    public long Cost { get; init; }

    [JsonProperty("Refund")]
    public long Refund { get; init; }
}