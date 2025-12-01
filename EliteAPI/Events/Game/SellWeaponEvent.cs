using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct SellWeaponEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Name")]
    public LocalisedField Name { get; init; }

    [JsonProperty("Price")]
    public long Price { get; init; }

    [JsonProperty("SuitModuleID")]
    public string SuitModuleId { get; init; }

    [JsonProperty("Class")]
    public int Class { get; init; }
}
