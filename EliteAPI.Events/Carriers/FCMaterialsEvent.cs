using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct FCMaterialsEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }
    
    [JsonProperty("event")]
    public string Event { get; init; }
    
    [JsonProperty("MarketID")]
    public string MarketId { get; init; }
    
    [JsonProperty("CarrierName")]
    public string CarrierName { get; init; }
    
    [JsonProperty("CarrierID")]
    public string CarrierId { get; init; }
}