using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ScannedEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("ScanType")]
    public string ScanType { get; init; }
}
