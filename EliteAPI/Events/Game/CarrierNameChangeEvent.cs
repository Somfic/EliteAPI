using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CarrierNameChangeEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("CarrierID")]
    public string CarrierId { get; init; }

    [JsonProperty("Callsign")]
    public string Callsign { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }
}
