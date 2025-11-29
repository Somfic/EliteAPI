using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct PassengersEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Manifest")]
    public IReadOnlyCollection<Manifest> Manifest { get; init; }
}

public readonly struct Manifest
{
    [JsonProperty("MissionID")]
    public long MissionId { get; init; }

    [JsonProperty("Type")]
    public string Type { get; init; }

    [JsonProperty("VIP")]
    public bool Vip { get; init; }

    [JsonProperty("Wanted")]
    public bool IsWanted { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }
}
