using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct JetConeDamageEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Module")]
    public LocalisedField Module { get; init; }
}
