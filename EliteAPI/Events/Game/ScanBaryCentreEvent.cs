using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ScanBaryCentreEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("StarSystem")]
    public string StarSystem { get; init; }

    [JsonProperty("BodyID")]
    public string BodyId { get; init; }

    [JsonProperty("SemiMajorAxis")]
    public double SemiMajorAxis { get; init; }

    [JsonProperty("Eccentricity")]
    public double Eccentricity { get; init; }

    [JsonProperty("OrbitalInclination")]
    public double OrbitalInclination { get; init; }

    [JsonProperty("Periapsis")]
    public double Periapsis { get; init; }

    [JsonProperty("OrbitalPeriod")]
    public double OrbitalPeriod { get; init; }

    [JsonProperty("AscendingNode")]
    public double AscendingNode { get; init; }

    [JsonProperty("MeanAnomaly")]
    public double MeanAnomaly { get; init; }
}
