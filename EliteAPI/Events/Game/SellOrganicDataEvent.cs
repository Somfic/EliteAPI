using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct SellOrganicDataEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("BioData")]
    public IReadOnlyCollection<BioDataInfo> BioData { get; init; }

    public readonly struct BioDataInfo
    {
        [JsonProperty("Genus")]
        public LocalisedField Genus { get; init; }

        [JsonProperty("Species")]
        public LocalisedField Species { get; init; }

        [JsonProperty("Variant")]
        public LocalisedField Variant { get; init; }

        [JsonProperty("Value")]
        public long Value { get; init; }

        [JsonProperty("Bonus")]
        public long Bonus { get; init; }
    }
}
