using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Status.Outfitting;

public readonly struct OutfittingEvent : IEvent
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
    
    [JsonProperty("Horizons")]
    public bool HasHorizons { get; init; }
    
    [JsonProperty("Items")]
    public IReadOnlyList<OutfittingItem> Items { get; init; }
}