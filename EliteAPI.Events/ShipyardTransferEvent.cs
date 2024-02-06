using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ShipyardTransferEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("ShipType")]
    public Localised ShipType { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }

    [JsonProperty("System")]
    public string System { get; init; }

    [JsonProperty("ShipMarketID")]
    public string ShipMarketId { get; init; }

    [JsonProperty("Distance")]
    public double Distance { get; init; }

    [JsonProperty("TransferPrice")]
    public long TransferPrice { get; init; }

    [JsonProperty("TransferTime")]
    public long TransferTime { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }
}