using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;


[Obsolete("Use DockSRVEvent instead", true)]
public readonly struct DockSrvEvent {};

public readonly struct DockSRVEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("ID")]
    public string Id { get; init; }
}