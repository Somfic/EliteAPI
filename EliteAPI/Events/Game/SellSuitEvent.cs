using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct SellSuitEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Name")]
    public LocalisedField Name { get; init; }

    [JsonProperty("Price")]
    public long Price { get; init; }

    [JsonProperty("SuitId")]
    public string SuitId { get; init; }

    [JsonProperty("SuitID")]
    public string SuitID { get; init; }
}
