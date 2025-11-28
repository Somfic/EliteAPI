using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct DropItemsEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Name")]
    public LocalisedField Name { get; init; }

    [JsonProperty("Type")]
    public string Type { get; init; }

    [JsonProperty("OwnerID")]
    public string OwnerId { get; init; }

    [JsonProperty("MissionID")]
    public string MissionId { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }
}
