using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct MusicEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("MusicTrack")]
    public string MusicTrack { get; init; }
}
