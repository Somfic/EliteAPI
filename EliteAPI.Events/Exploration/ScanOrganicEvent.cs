using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ScanOrganicEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }
    
    [JsonProperty("event")]
    public string Event { get; init; }
    
    [JsonProperty("ScanType")]
    public string ScanType { get; init; } // TODO: Create enum
    
    [JsonProperty("Genus")]
    public Localised Genus { get; init; }
    
    [JsonProperty("Species")]
    public Localised Species { get; init; }
    
    [JsonProperty("Variant")]
    public Localised Variant { get; init; }
    
    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }
    
    [JsonProperty("Body")]
    public int Body { get; init; }
}