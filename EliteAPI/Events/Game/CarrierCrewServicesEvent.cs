using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CarrierCrewServicesEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("CarrierID")]
    public string CarrierId { get; init; }

    [JsonProperty("Operation")]
    public string Operation { get; init; }

    [JsonProperty("CrewRole")]
    public string CrewRole { get; init; }

    [JsonProperty("CrewName")]
    public string CrewName { get; init; }
}
