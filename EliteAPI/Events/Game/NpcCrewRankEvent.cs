using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct NpcCrewRankEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("NpcCrewId")]
    public string CrewId { get; init; }

    [JsonProperty("NpcCrewName")]
    public string CrewName { get; init; }

    [JsonProperty("RankCombat")]
    public long RankCombat { get; init; }
}
