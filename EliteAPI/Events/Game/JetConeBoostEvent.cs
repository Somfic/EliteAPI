using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct JetConeBoostEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("BoostValue")]
    public double BoostValue { get; init; }
}
