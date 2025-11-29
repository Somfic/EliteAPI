using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct BackpackChangeEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Added")]
    public IReadOnlyCollection<BackpackItemInfo> Added { get; init; }

    [JsonProperty("Removed")]
    public IReadOnlyCollection<BackpackItemInfo> Removed { get; init; }

    public readonly struct BackpackItemInfo
    {
        [JsonProperty("Name")]
        public LocalisedField Name { get; init; }

        [JsonProperty("OwnerID")]
        public string OwnerId { get; init; }

        [JsonProperty("Count")]
        public long Count { get; init; }

        [JsonProperty("Type")]
        public string Type { get; init; }
    }
}
