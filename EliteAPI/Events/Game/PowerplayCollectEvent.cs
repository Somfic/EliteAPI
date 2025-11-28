using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct PowerplayCollectEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Power")]
    public string Power { get; init; }

    [JsonProperty("Type")]
    public LocalisedField Type { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }
}
