using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct JoinACrewEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Captain")]
    public string Captain { get; init; }

    [JsonProperty("Telepresence")]
    public bool IsInTelepresence { get; init; }
}
