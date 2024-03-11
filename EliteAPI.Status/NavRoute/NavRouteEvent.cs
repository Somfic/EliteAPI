using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Status.NavRoute;

public readonly struct NavRouteEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Route")]
    public IReadOnlyList<NavRouteStop> Stops { get; init; }
}