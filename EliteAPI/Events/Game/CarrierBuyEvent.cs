using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CarrierBuyEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("BoughtAtMarket")]
    public string MarketId { get; init; }

    [JsonProperty("CarrierID")]
    public string CarrierId { get; init; }

    [JsonProperty("Location")]
    public string StarSystem { get; init; }

    [JsonProperty("Price")]
    public long Price { get; init; }

    [JsonProperty("Variant")]
    public string Variant { get; init; }

    [JsonProperty("Callsign")]
    public string CallSign { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }
}
