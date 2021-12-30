using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct PayFinesEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Amount")]
    public long Amount { get; init; }

    [JsonProperty("AllFines")]
    public bool IsAllFines { get; init; }

    [JsonProperty("Faction")]
    public string Faction { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }
}