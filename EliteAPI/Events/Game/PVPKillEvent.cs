using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct PvpKillEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Victim")]
    public string Victim { get; init; }

    [JsonProperty("CombatRank")]
    public long CombatRank { get; init; }
}
