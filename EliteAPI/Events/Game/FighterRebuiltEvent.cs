using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct FighterRebuiltEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Loadout")]
    public string Loadout { get; init; }

    [JsonProperty("ID")]
    public string Id { get; init; }
}
