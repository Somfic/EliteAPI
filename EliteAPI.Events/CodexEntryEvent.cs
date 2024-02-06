using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CodexEntryEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("EntryID")]
    public string EntryId { get; init; }

    [JsonProperty("Name")]
    public Localised Name { get; init; }

    [JsonProperty("SubCategory")]
    public Localised SubCategory { get; init; }

    [JsonProperty("Category")]
    public Localised Category { get; init; }

    [JsonProperty("Region")]
    public Localised Region { get; init; }

    [JsonProperty("System")]
    public string System { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("IsNewEntry")]
    public bool IsNewEntry { get; init; }

    [JsonProperty("NearestDestination")]
    public Localised NearestDestination { get; init; }
}