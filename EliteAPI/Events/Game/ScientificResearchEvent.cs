using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ScientificResearchEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }

    [JsonProperty("Category")]
    public string Category { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }
}
