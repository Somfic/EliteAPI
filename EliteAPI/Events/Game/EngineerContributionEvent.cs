using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct EngineerContributionEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Engineer")]
    public string Engineer { get; init; }

    [JsonProperty("Type")]
    public string Type { get; init; }

    [JsonProperty("Material")]
    public string Material { get; init; }

    [JsonProperty("Quantity")]
    public long Quantity { get; init; }

    [JsonProperty("TotalQuantity")]
    public long TotalQuantity { get; init; }

    [JsonProperty("EngineerID")]
    public string EngineerID { get; init; }

    [JsonProperty("Commodity")]
    public string Commodity { get; init; }
}
