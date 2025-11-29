using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct BuyExplorationDataEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("System")]
    public string System { get; init; }

    [JsonProperty("Cost")]
    public long Cost { get; init; }
}
