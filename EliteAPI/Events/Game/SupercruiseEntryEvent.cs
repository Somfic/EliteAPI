using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct SupercruiseEntryEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("StarSystem")]
    public string StarSystem { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("Taxi")]
    public bool IsTaxi { get; init; }

    [JsonProperty("Multicrew")]
    public bool IsMulticrew { get; init; }

    [JsonProperty("Wanted")]
    public bool IsWanted { get; init; }
}
