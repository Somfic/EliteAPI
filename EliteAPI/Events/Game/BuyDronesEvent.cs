using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct BuyDronesEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Type")]
    public string Type { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }

    [JsonProperty("BuyPrice")]
    public long BuyPrice { get; init; }

    [JsonProperty("TotalCost")]
    public long TotalCost { get; init; }
}
