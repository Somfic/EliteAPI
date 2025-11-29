using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

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
