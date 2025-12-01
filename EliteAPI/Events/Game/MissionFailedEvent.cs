using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct MissionFailedEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }

    [JsonProperty("MissionID")]
    public string MissionId { get; init; }

    [JsonProperty("LocalisedName")]
    public string LocalisedName { get; init; }

    [JsonProperty("Fine")]
    public int Fine { get; init; }
}
