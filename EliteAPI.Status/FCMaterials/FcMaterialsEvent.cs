using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events.Status.FCMaterials;

public readonly struct FcMaterialsEvent : IEvent
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

    [JsonProperty("Items")]
    public IReadOnlyCollection<FcMaterial> Materials { get; init; }
}