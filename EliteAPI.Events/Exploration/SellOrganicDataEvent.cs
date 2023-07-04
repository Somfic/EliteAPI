using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

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
        public Localised Genus { get; init; }

        [JsonProperty("Species")] 
        public Localised Species { get; init; }

        [JsonProperty("Variant")] 
        public Localised Variant { get; init; }
        
        [JsonProperty("Value")]
        public long Value { get; init; }
        
        [JsonProperty("Bonus")]
        public long Bonus { get; init; }
    }
}