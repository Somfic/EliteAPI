using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CargoDepotEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("MissionID")]
    public string MissionId { get; init; }

    [JsonProperty("UpdateType")]
    public string UpdateType { get; init; }

    [JsonProperty("CargoType")]
    public Localised CargoType { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }

    [JsonProperty("StartMarketID")]
    public string StartMarketId { get; init; }

    [JsonProperty("EndMarketID")]
    public string EndMarketId { get; init; }

    [JsonProperty("ItemsCollected")]
    public long ItemsCollected { get; init; }

    [JsonProperty("ItemsDelivered")]
    public long ItemsDelivered { get; init; }

    [JsonProperty("TotalItemsToDeliver")]
    public long TotalItemsToDeliver { get; init; }

    [JsonProperty("Progress")]
    public double Progress { get; init; }
}