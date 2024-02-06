using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ModuleSwapEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("FromSlot")]
    public string FromSlot { get; init; }

    [JsonProperty("ToSlot")]
    public string ToSlot { get; init; }

    [JsonProperty("FromItem")]
    public Localised FromItem { get; init; }

    [JsonProperty("ToItem")]
    public Localised ToItem { get; init; }

    [JsonProperty("Ship")]
    public string Ship { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }
}