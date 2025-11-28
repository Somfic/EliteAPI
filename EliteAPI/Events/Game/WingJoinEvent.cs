using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct WingJoinEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Others")]
    public IReadOnlyCollection<string> Others { get; init; }
}
