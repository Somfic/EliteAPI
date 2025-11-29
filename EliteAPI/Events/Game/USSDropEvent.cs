using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct UssDropEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("USSType")]
    public LocalisedField USSType { get; init; }

    [JsonProperty("USSThreat")]
    public long UssThreat { get; init; }
}
