using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct InterdictedEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Submitted")]
    public bool HasSubmitted { get; init; }

    [JsonProperty("Interdictor")]
    public LocalisedField Interdictor { get; init; }

    [JsonProperty("IsPlayer")]
    public bool IsPlayer { get; init; }

    [JsonProperty("Faction")]
    public string Faction { get; init; }

    [JsonProperty("IsThargoid")]
    public bool IsThargoid { get; init; }

    [JsonProperty("CombatRank")]
    public int CombatRank { get; init; }

    [JsonProperty("Power")]
    public string Power { get; init; }
}
