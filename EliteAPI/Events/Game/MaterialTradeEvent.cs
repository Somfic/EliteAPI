using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct MaterialTradeEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("TraderType")]
    public string TraderType { get; init; }

    [JsonProperty("Paid")]
    public Paid Paid { get; init; }

    [JsonProperty("Received")]
    public Paid Received { get; init; }
}

public readonly struct Paid
{
    [JsonProperty("Material")]
    public LocalisedField Material { get; init; }

    [JsonProperty("Category")]
    public string Category { get; init; }

    [JsonProperty("Quantity")]
    public long Quantity { get; init; }
}
