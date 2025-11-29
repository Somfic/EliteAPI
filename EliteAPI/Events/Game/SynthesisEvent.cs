using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct SynthesisEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }

    [JsonProperty("Materials")]
    public IReadOnlyCollection<MaterialInfo> Materials { get; init; }
}

public readonly struct MaterialInfo
{
    [JsonProperty("Name")]
    public string Name { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }
}
