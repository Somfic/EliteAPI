using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ShipTargetedEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("TargetLocked")]
    public bool IsTargetLocked { get; init; }

    [JsonProperty("Ship")]
    public Localised Ship { get; init; }

    [JsonProperty("ScanStage")]
    public long ScanStage { get; init; }

    [JsonProperty("PilotName")]
    public Localised PilotName { get; init; }

    [JsonProperty("PilotRank")]
    public string PilotRank { get; init; }

    [JsonProperty("SquadronID")]
    public string SquadronId { get; init; }

    [JsonProperty("ShieldHealth")]
    public double ShieldHealth { get; init; }

    [JsonProperty("HullHealth")]
    public double HullHealth { get; init; }

    [JsonProperty("LegalStatus")]
    public string LegalStatus { get; init; }

    [JsonProperty("Faction")]
    public string Faction { get; init; }

    [JsonProperty("Subsystem")]
    public Localised Subsystem { get; init; }

    [JsonProperty("SubsystemHealth")]
    public double SubsystemHealth { get; init; }
}