using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct MiningRefinedEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Type")]
    public LocalisedField Type { get; init; }
}
