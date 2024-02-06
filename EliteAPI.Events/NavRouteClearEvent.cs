using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct NavRouteClearEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }
    
    [JsonProperty("event")]
    public string Event { get; init; }
}