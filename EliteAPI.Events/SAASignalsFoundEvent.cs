using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct SaaSignalsFoundEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("BodyName")]
    public string BodyName { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("BodyID")]
    public string BodyId { get; init; }

    [JsonProperty("Signals")]
    public IReadOnlyCollection<Signal> Signals { get; init; }
    
    [JsonProperty("Genuses")]
    public IReadOnlyCollection<Genus> Genuses { get; init; }
}

public readonly struct Signal
{
    [JsonProperty("Type")]
    public Localised Type { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }
}

public readonly struct Genus
{
    [JsonProperty("Genus")]
    public Localised Name { get; init; }
}