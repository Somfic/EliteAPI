using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct PowerplayDefectEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("FromPower")]
    public string FromPower { get; init; }

    [JsonProperty("ToPower")]
    public string ToPower { get; init; }
}
