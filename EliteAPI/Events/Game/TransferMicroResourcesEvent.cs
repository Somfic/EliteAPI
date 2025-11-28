using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct TransferMicroResourcesEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Transfers")]
    public IReadOnlyCollection<MicroResourceInfo> Transfers { get; init; }


    public readonly struct MicroResourceInfo
    {
        [JsonProperty("Name")]
        public LocalisedField Name { get; init; }

        [JsonProperty("Category")]
        public string Category { get; init; }

        [JsonProperty("Count")]
        public long Count { get; init; }

        [JsonProperty("Direction")]
        public string Direction { get; init; }
    }
}
