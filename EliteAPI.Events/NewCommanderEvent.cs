using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct NewCommanderEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }

    [JsonProperty("FID")]
    public string FrontierId { get; init; }

    [JsonProperty("Package")]
    public string StarterPackage { get; init; }
}