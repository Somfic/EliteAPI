using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CarrierFinanceEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("CarrierID")]
    public string CarrierId { get; init; }

    [JsonProperty("TaxRate")]
    public int TaxRate { get; init; }

    [JsonProperty("CarrierBalance")]
    public long Balance { get; init; }

    [JsonProperty("ReserveBalance")]
    public long ReserveBalance { get; init; }

    [JsonProperty("AvailableBalance")]
    public long AvailableBalance { get; init; }

    [JsonProperty("ReservePercent")]
    public int ReservePercent { get; init; }
}