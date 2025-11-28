using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ScanOrganicEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("ScanType")]
    public string ScanType { get; init; } // TODO: Create enum

    [JsonProperty("Genus")]
    public LocalisedField Genus { get; init; }

    [JsonProperty("Species")]
    public LocalisedField Species { get; init; }

    [JsonProperty("Variant")]
    public LocalisedField Variant { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("Body")]
    public long Body { get; init; }
}
