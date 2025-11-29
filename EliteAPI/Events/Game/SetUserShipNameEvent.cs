using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct SetUserShipNameEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Ship")]
    public string Ship { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }

    [JsonProperty("UserShipName")]
    public string UserShipName { get; init; }

    [JsonProperty("UserShipId")]
    public string UserShipId { get; init; }
}
