using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct TradeMicroResourcesEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Offered")]
    public IReadOnlyCollection<MicroResourceInfo> Transfers { get; init; }

    [JsonProperty("Received")]
    public string Received { get; init; }
    
    [JsonProperty("Count")]
    public long Count { get; init; }
    
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