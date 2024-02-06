using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ModuleSellRemoteEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("StorageSlot")]
    public string StorageSlot { get; init; }

    [JsonProperty("SellItem")]
    public Localised SellItem { get; init; }

    [JsonProperty("ServerId")]
    public string ServerId { get; init; }

    [JsonProperty("SellPrice")]
    public long SellPrice { get; init; }

    [JsonProperty("Ship")]
    public string Ship { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }
}