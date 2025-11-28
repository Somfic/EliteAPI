using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct RepairEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Item")]
    public string Item { get; init; }

    [JsonProperty("Cost")]
    public long Cost { get; init; }
}
