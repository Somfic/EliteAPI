using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct SellDronesEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Type")]
    public string Type { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }

    [JsonProperty("SellPrice")]
    public long SellPrice { get; init; }

    [JsonProperty("TotalSale")]
    public long TotalSale { get; init; }
}
