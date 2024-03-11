using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Status.Shipyard;

public readonly struct ShipyardEvent : IEvent
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

    [JsonProperty("AllowCobraMkIV")]
    public bool AllowsCobraMk4 { get; init; }

    [JsonProperty("PriceList")]
    public IReadOnlyList<ShipyardDeal> Deals { get; init; }
}   