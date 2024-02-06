using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ModuleSellEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("Slot")]
    public string Slot { get; init; }

    [JsonProperty("SellItem")]
    public Localised SellItem { get; init; }

    [JsonProperty("SellPrice")]
    public long SellPrice { get; init; }

    [JsonProperty("Ship")]
    public string Ship { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }
}