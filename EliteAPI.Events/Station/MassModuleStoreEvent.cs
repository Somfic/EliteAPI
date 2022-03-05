using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct MassModuleStoreEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("Ship")]
    public string Ship { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }

    [JsonProperty("Items")]
    public IReadOnlyCollection<Item> Items { get; init; }
}