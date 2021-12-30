using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct PayLegacyFinesEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Amount")]
    public long Amount { get; init; }

    [JsonProperty("BrokerPercentage")]
    public double BrokerPercentage { get; init; }
}