using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CommitCrimeEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("CrimeType")]
    public string CrimeType { get; init; }

    [JsonProperty("Faction")]
    public string Faction { get; init; }

    [JsonProperty("Fine")]
    public long Fine { get; init; }

    [JsonProperty("Victim")]
    public Localised Victim { get; init; }

    [JsonProperty("Bounty")]
    public long Bounty { get; init; }
}