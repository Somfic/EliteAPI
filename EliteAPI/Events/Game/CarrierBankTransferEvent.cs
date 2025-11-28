using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public struct CarrierBankTransferEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

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
}
