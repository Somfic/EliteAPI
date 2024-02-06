using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

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
    public Localised NearestDestination { get; init; }
}