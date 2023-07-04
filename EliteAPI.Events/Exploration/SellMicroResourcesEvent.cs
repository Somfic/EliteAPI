using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct SellMicroResourcesEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }
    
    [JsonProperty("event")]
    public string Event { get; init; }
    
    [JsonProperty("MicroResources")]
    public IReadOnlyCollection<MicroResourceInfo> MicroResources { get; init; }
    
    [JsonProperty("Price")]
    public long Price { get; init; }
    
    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    public readonly struct MicroResourceInfo
    {
        [JsonProperty("Name")]
        public Localised Name { get; init; }
        
        [JsonProperty("Category")]
        public string Category { get; init; }
        
        [JsonProperty("Count")]
        public long Count { get; init; }
    }
}