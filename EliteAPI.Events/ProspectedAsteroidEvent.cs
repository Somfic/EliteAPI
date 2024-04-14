using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ProspectedAsteroidEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Materials")]
    public IReadOnlyCollection<Material> Materials { get; init; }

    [JsonProperty("MotherlodeMaterial")]
    public Localised Motherlode { get; init; }

    [JsonProperty("Content")]
    public Localised Content { get; init; }

    [JsonProperty("Remaining")]
    public double Remaining { get; init; }
}

public readonly struct Material
{
    [JsonProperty("Name")]
    public Localised Name { get; init; }

    [JsonProperty("Proportion")]
    public double Proportion { get; init; }
}