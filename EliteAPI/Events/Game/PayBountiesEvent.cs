using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct PayBountiesEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Amount")]
    public long Amount { get; init; }

    [JsonProperty("Faction")]
    public LocalisedField Faction { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }

    [JsonProperty("BrokerPercentage")]
    public double BrokerPercentage { get; init; }

    [JsonProperty("AllFines")]
    public bool IsAllFines { get; init; }
}
