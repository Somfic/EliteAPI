using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ShipyardBuyEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("ShipType")]
    public Localised ShipType { get; init; }

    [JsonProperty("ShipPrice")]
    public long ShipPrice { get; init; }

    [JsonProperty("StoreOldShip")]
    public string StoreOldShip { get; init; }

    [JsonProperty("StoreShipID")]
    public string StoreShipId { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }
}