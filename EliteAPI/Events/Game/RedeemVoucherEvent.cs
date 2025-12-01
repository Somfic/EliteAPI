using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct RedeemVoucherEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Type")]
    public string Type { get; init; }

    [JsonProperty("Amount")]
    public long Amount { get; init; }

    [JsonProperty("Faction")]
    public string Faction { get; init; }

    [JsonProperty("BrokerPercentage")]
    public double BrokerPercentage { get; init; }
}
