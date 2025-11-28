using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct DockFighterEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("ID")]
    public string Id { get; init; }
}
