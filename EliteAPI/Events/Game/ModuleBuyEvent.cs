using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ModuleBuyEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Slot")]
    public string Slot { get; init; }

    [JsonProperty("BuyItem")]
    public LocalisedField BuyItem { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("BuyPrice")]
    public long BuyPrice { get; init; }

    [JsonProperty("Ship")]
    public string Ship { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }

    [JsonProperty("StoredItem")]
    public string StoredItem { get; init; }

    [JsonProperty("SellItem")]
    public string SellItem { get; init; }

    [JsonProperty("SellPrice")]
    public int SellPrice { get; init; }
}
