using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public struct CarrierBankTransferEvent : IEvent
{
    [JsonProperty("CarrierID")]
    public string CarrierId { get; init; }

    [JsonProperty("Deposit")]
    public long Deposit { get; init; }

    [JsonProperty("Withdraw")]
    public long Withdraw { get; init; }

    [JsonProperty("PlayerBalance")]
    public long PlayerBalance { get; init; }

    [JsonProperty("CarrierBalance")]
    public long CarrierBalance { get; init; }

    public DateTime Timestamp { get; }

    public string Event { get; }
}