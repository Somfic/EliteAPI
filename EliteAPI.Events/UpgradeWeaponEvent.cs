using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct UpgradeWeaponEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Name")]
    public Localised Name { get; init; }

    [JsonProperty("Class")]
    public long Class { get; init; }

    [JsonProperty("SuitModuleID")]
    public string SuitModuleId { get; init; }

    [JsonProperty("Cost")]
    public long Cost { get; init; }
}