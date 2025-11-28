using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CommanderEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("FID")]
    public string Fid { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }
}
