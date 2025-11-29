using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct RenameSuitLoadoutEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("SuitID")]
    public string SuitId { get; init; }

    [JsonProperty("SuitName")]
    public LocalisedField SuitName { get; init; }

    [JsonProperty("LoadoutID")]
    public string LoadoutId { get; init; }

    [JsonProperty("LoadoutName")]
    public string LoadoutName { get; init; }
}
