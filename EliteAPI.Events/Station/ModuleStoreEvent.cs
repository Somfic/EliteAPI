using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ModuleStoreEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Slot")]
    public string Slot { get; init; }

    [JsonProperty("StoredItem")]
    public Localised StoredItem { get; init; }

    [JsonProperty("Ship")]
    public string Ship { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }

    [JsonProperty("EngineerModifications")]
    public string EngineerModifications { get; init; }
}