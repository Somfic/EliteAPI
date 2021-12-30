using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CarrierTradeOrderEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("CarrierID")]
    public string CarrierId { get; init; }

    [JsonProperty("BlackMarket")]
    public bool IsBlackMarket { get; init; }

    [JsonProperty("Commodity")]
    public Localised Commodity { get; init; }

    [JsonProperty("PurchaseOrder")]
    public int PurchaseOrder { get; init; }

    [JsonProperty("SaleOrder")]
    public int SaleOrder { get; init; }

    [JsonProperty("CancelTrade")]
    public bool IsCancelTrade { get; init; }

    [JsonProperty("Price")]
    public long Price { get; init; }
}