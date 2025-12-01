using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct KickCrewMemberEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Crew")]
    public string Crew { get; init; }

    [JsonProperty("OnCrime")]
    public bool IsCrime { get; init; }

    [JsonProperty("Telepresence")]
    public bool IsInTelepresence { get; init; }
}
