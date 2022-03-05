using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct MaterialDiscoveredEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Category")]
    public string Category { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }

    [JsonProperty("DiscoveryNumber")]
    public long DiscoveryNumber { get; init; }
}