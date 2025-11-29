using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct UseConsumableEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Name")]
    public LocalisedField Name { get; init; }

    [JsonProperty("Type")]
    public string Type { get; init; }
}
