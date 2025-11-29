using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ShipyardTransferEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("ShipType")]
    public LocalisedField ShipType { get; init; }

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
