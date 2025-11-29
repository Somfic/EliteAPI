using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CarrierDockingPermissionEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("CarrierID")]
    public string CarrierId { get; init; }

    [JsonProperty("DockingAccess")]
    public string DockingAccess { get; init; }

    [JsonProperty("AllowNotorious")]
    public bool AllowsNotorious { get; init; }
}
