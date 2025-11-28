using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct MaterialCollectedEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Category")]
    public string Category { get; init; }

    [JsonProperty("Name")]
    public LocalisedField Name { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }
}
