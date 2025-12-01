using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct LiftoffEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("PlayerControlled")]
    public bool IsPlayerControlled { get; init; }

    [JsonProperty("Latitude")]
    public double Latitude { get; init; }

    [JsonProperty("Longitude")]
    public double Longitude { get; init; }

    [JsonProperty("StarSystem")]
    public string StarSystem { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("Body")]
    public string Body { get; init; }

    [JsonProperty("BodyID")]
    public string BodyId { get; init; }

    [JsonProperty("OnPlanet")]
    public bool IsOnPlanet { get; init; }

    [JsonProperty("OnStation")]
    public bool IsOnStation { get; init; }

    [JsonProperty("NearestDestination")]
    public LocalisedField NearestDestination { get; init; }

    [JsonProperty("Taxi")]
    public bool IsInTaxi { get; init; }

    [JsonProperty("Multicrew")]
    public bool IsMulticrew { get; init; }
}
