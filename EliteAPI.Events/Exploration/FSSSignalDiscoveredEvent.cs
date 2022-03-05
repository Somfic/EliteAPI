using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct FssSignalDiscoveredEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("SignalName")]
    public string SignalName { get; init; }
}