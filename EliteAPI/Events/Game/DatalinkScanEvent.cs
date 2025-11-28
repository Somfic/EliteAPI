using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct DatalinkScanEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Message")]
    public LocalisedField Message { get; init; }
}
