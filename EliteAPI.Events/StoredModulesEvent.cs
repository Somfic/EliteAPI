using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct StoredModulesEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("StationName")]
    public string StationName { get; init; }

    [JsonProperty("StarSystem")]
    public string StarSystem { get; init; }

    [JsonProperty("Items")]
    public IReadOnlyCollection<Item> Items { get; init; }
}

public readonly struct Item
{
    [JsonProperty("Name")]
    public Localised Name { get; init; }

    [JsonProperty("StorageSlot")]
    public long StorageSlot { get; init; }

    [JsonProperty("StarSystem")]
    public string StarSystem { get; init; }

    [JsonProperty("MarketID")]
    public long MarketId { get; init; }

    [JsonProperty("TransferCost")]
    public long TransferCost { get; init; }

    [JsonProperty("TransferTime")]
    public long TransferTime { get; init; }

    [JsonProperty("BuyPrice")]
    public long BuyPrice { get; init; }

    [JsonProperty("Hot")]
    public bool Hot { get; init; }

    [JsonProperty("EngineerModifications")]
    public string EngineerModifications { get; init; }

    [JsonProperty("Level")]
    public long Level { get; init; }

    [JsonProperty("Quality")]
    public double Quality { get; init; }
}