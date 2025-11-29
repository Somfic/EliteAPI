using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

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
    public LocalisedField FromItem { get; init; }

    [JsonProperty("ToItem")]
    public LocalisedField ToItem { get; init; }

    [JsonProperty("Ship")]
    public string Ship { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }
}
