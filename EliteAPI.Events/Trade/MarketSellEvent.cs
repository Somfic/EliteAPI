using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct MarketSellEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("Type")]
    public Localised Type { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }

    [JsonProperty("SellPrice")]
    public long SellPrice { get; init; }

    [JsonProperty("TotalSale")]
    public long TotalSale { get; init; }

    [JsonProperty("AvgPricePaid")]
    public long AvgPricePaid { get; init; }

    [JsonProperty("IllegalGoods")]
    public bool HasIllegalGoods { get; init; }

    [JsonProperty("StolenGoods")]
    public bool HasStolenGoods { get; init; }

    [JsonProperty("BlackMarket")]
    public bool IsBlackMarket { get; init; }
}