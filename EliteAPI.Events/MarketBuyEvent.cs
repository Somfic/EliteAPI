using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct MarketBuyEvent : IEvent
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

    [JsonProperty("BuyPrice")]
    public long BuyPrice { get; init; }

    [JsonProperty("TotalCost")]
    public long TotalCost { get; init; }
}