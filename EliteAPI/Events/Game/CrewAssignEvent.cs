using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CrewAssignEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }

    [JsonProperty("CrewID")]
    public string CrewId { get; init; }

    [JsonProperty("Role")]
    public string Role { get; init; }
}
