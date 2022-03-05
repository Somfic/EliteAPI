using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct MissionAcceptedEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Faction")]
    public string Faction { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }

    [JsonProperty("LocalisedName")]
    public string LocalisedName { get; init; }

    [JsonProperty("TargetType")]
    public Localised TargetType { get; init; }

    [JsonProperty("TargetFaction")]
    public string TargetFaction { get; init; }

    [JsonProperty("DestinationSystem")]
    public string DestinationSystem { get; init; }

    [JsonProperty("DestinationStation")]
    public string DestinationStation { get; init; }

    [JsonProperty("Target")]
    public string Target { get; init; }

    [JsonProperty("Expiry")]
    public DateTime Expiry { get; init; }

    [JsonProperty("Wing")]
    public bool IsWing { get; init; }

    [JsonProperty("Influence")]
    public string Influence { get; init; }

    [JsonProperty("Reputation")]
    public string Reputation { get; init; }

    [JsonProperty("Reward")]
    public long Reward { get; init; }

    [JsonProperty("MissionID")]
    public string MissionId { get; init; }

    [JsonProperty("KillCount")]
    public int KillCount { get; init; }
}