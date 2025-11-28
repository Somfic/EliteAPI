using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct NpcCrewPaidWageEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("NpcCrewName")]
    public string NpcCrewName { get; init; }

    [JsonProperty("NpcCrewId")]
    public string NpcCrewId { get; init; }

    [JsonProperty("Amount")]
    public long Amount { get; init; }
}
