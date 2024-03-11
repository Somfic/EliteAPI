using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Status.Modules;

public readonly struct ModuleInfoEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }
    
    [JsonProperty("Modules")]
    public IReadOnlyList<ShipModule> Installed { get; init; }
}