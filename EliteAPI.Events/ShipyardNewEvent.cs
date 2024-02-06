using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ShipyardNewEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("ShipType")]
    public Localised ShipType { get; init; }

    [JsonProperty("NewShipID")]
    public string NewShipId { get; init; }
}