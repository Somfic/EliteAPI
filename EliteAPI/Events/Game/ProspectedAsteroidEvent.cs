using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ProspectedAsteroidEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Materials")]
    public IReadOnlyCollection<Material> Materials { get; init; }

    [JsonProperty("MotherlodeMaterial")]
    public LocalisedField Motherlode { get; init; }

    [JsonProperty("Content")]
    public LocalisedField Content { get; init; }

    [JsonProperty("Remaining")]
    public double Remaining { get; init; }
}

public readonly struct Material
{
    [JsonProperty("Name")]
    public LocalisedField Name { get; init; }

    [JsonProperty("Proportion")]
    public double Proportion { get; init; }
}
