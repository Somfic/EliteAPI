using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct FriendsEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Status")]
    public string Status { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }
}
