using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events.Status.Cargo;

public readonly struct CargoItem
{
    [JsonProperty("Name")]
    public Localised Name { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }

    [JsonProperty("Stolen")]
    public bool IsStolen { get; init; }

    [JsonProperty("MissionID")]
    public string MissionId { get; init; }
}