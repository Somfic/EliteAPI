using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events.Status.FCMaterials;

public readonly struct FcMaterial
{
    [JsonProperty("id")]
    public long Id { get; init; }

    [JsonProperty("Name")]
    public Localised Name { get; init; }

    [JsonProperty("Price")]
    public long Price { get; init; }

    [JsonProperty("Stock")]
    public long Stock { get; init; }

    [JsonProperty("Demand")]
    public long Demand { get; init; }
}