using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ModuleStoreEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Slot")]
    public string Slot { get; init; }

    [JsonProperty("StoredItem")]
    public LocalisedField StoredItem { get; init; }

    [JsonProperty("Ship")]
    public string Ship { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }

    [JsonProperty("EngineerModifications")]
    public string EngineerModifications { get; init; }

    [JsonProperty("MarketID")]
    public string MarketID { get; init; }

    [JsonProperty("ReplacementItem")]
    public string ReplacementItem { get; init; }

    [JsonProperty("Hot")]
    public bool IsHot { get; init; }

    [JsonProperty("Level")]
    public int Level { get; init; }

    [JsonProperty("Quality")]
    public double Quality { get; init; }

    [JsonProperty("Cost")]
    public int Cost { get; init; }
}
