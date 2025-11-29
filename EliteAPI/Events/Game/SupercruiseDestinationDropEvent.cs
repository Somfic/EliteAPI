using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct SupercruiseDestinationDropEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Type")]
    public string Type { get; init; }

    [JsonProperty("Threat")]
    public long Threat { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }
}
