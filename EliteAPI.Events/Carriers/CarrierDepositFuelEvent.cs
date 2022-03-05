using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CarrierDepositFuelEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("CarrierID")]
    public string CarrierId { get; init; }

    [JsonProperty("Amount")]
    public int Amount { get; init; }

    [JsonProperty("Total")]
    public int Total { get; init; }
}