using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct RestockVehicleEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Type")]
    public string Type { get; init; }

    [JsonProperty("Loadout")]
    public string Loadout { get; init; }

    [JsonProperty("Cost")]
    public long Cost { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }

    [JsonProperty("ID")]
    public string ID { get; init; }
}
