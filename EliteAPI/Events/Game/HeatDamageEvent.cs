using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct HeatDamageEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("ID")]
    public string ID { get; init; }
}
