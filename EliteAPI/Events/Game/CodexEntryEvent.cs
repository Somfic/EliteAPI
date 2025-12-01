using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CodexEntryEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("EntryID")]
    public string EntryId { get; init; }

    [JsonProperty("Name")]
    public LocalisedField Name { get; init; }

    [JsonProperty("SubCategory")]
    public LocalisedField SubCategory { get; init; }

    [JsonProperty("Category")]
    public LocalisedField Category { get; init; }

    [JsonProperty("Region")]
    public LocalisedField Region { get; init; }

    [JsonProperty("System")]
    public string System { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("IsNewEntry")]
    public bool IsNewEntry { get; init; }

    [JsonProperty("NearestDestination")]
    public LocalisedField NearestDestination { get; init; }

    [JsonProperty("BodyID")]
    public string BodyID { get; init; }

    [JsonProperty("Latitude")]
    public double Latitude { get; init; }

    [JsonProperty("Longitude")]
    public double Longitude { get; init; }

    [JsonProperty("VoucherAmount")]
    public int VoucherAmount { get; init; }

    [JsonProperty("NewTraitsDiscovered")]
    public bool HasNewTraitsDiscovered { get; init; }
}
