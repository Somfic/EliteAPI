using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct SquadronStartupEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("SquadronName")]
    public string SquadronName { get; init; }

    [JsonProperty("CurrentRank")]
    public long CurrentRank { get; init; }
}
