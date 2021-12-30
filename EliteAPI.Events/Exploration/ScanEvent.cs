using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ScanEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("ScanType")]
    public string ScanType { get; init; }

    [JsonProperty("BodyName")]
    public string BodyName { get; init; }

    [JsonProperty("BodyID")]
    public string BodyId { get; init; }

    [JsonProperty("Parents")]
    public IReadOnlyCollection<ParentInfo> Parents { get; init; }

    [JsonProperty("StarSystem")]
    public string StarSystem { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("DistanceFromArrivalLS")]
    public double DistanceFromArrivalLs { get; init; }

    [JsonProperty("StarType")]
    public string StarType { get; init; }

    [JsonProperty("StarClass")]
    public long StarClass { get; init; }

    [JsonProperty("StellarMass")]
    public double StellarMass { get; init; }

    [JsonProperty("Radius")]
    public double Radius { get; init; }

    [JsonProperty("AbsoluteMagnitude")]
    public double AbsoluteMagnitude { get; init; }

    [JsonProperty("Age_MY")]
    public long AgeMy { get; init; }

    [JsonProperty("SurfaceTemperature")]
    public double SurfaceTemperature { get; init; }

    [JsonProperty("Luminosity")]
    public string Luminosity { get; init; }

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

    [JsonProperty("RotationPeriod")]
    public double RotationPeriod { get; init; }

    [JsonProperty("AxialTilt")]
    public double AxialTilt { get; init; }

    [JsonProperty("Rings")]
    public IReadOnlyCollection<RingInfo> Rings { get; init; }

    [JsonProperty("WasDiscovered")]
    public bool WasDiscovered { get; init; }

    [JsonProperty("WasMapped")]
    public bool WasMapped { get; init; }

    [JsonProperty("TidalLock")]
    public bool IsTidalLock { get; init; }

    [JsonProperty("TerraformState")]
    public string TerraformState { get; init; }

    [JsonProperty("PlanetState")]
    public string PlanetState { get; init; }

    [JsonProperty("PlanetClass")]
    public string PlanetClass { get; init; }

    [JsonProperty("Atmosphere")]
    public string Atmosphere { get; init; }

    [JsonProperty("AtmosphereType")]
    public string AtmosphereType { get; init; }

    [JsonProperty("Volcanism")]
    public string Volcanism { get; init; }

    [JsonProperty("MassEM")]
    public double MassEm { get; init; }

    [JsonProperty("SurfaceGravity")]
    public double SurfaceGravity { get; init; }

    [JsonProperty("SurfacePressure")]
    public double SurfacePressure { get; init; }

    [JsonProperty("Landable")]
    public bool IsLandable { get; init; }

    [JsonProperty("Materials")]
    public IReadOnlyCollection<MaterialInfo> Materials { get; init; }

    [JsonProperty("Composition")]
    public CompositionInfo Composition { get; init; }

    [JsonProperty("AtmosphereComposition")]
    public IReadOnlyCollection<AtmosphereCompositionInfo> AtmosphereComposition { get; init; }

    [JsonProperty("ReserveLevel")]
    public string ReserveLevel { get; init; }


    public readonly struct ParentInfo
    {
        [JsonProperty("Null")]
        public long Null { get; init; }
    }


    public readonly struct RingInfo
    {
        [JsonProperty("Name")]
        public string Name { get; init; }

        [JsonProperty("RingClass")]
        public string RingClass { get; init; }

        [JsonProperty("MassMT")]
        public long MassMt { get; init; }

        [JsonProperty("InnerRad")]
        public long InnerRad { get; init; }

        [JsonProperty("OuterRad")]
        public long OuterRad { get; init; }
    }


    public readonly struct MaterialInfo
    {
        [JsonProperty("Name")]
        public string Name { get; init; }

        [JsonProperty("Percent")]
        public double Percent { get; init; }
    }


    public readonly struct AtmosphereCompositionInfo
    {
        [JsonProperty("Name")]
        public string Name { get; init; }

        [JsonProperty("Percent")]
        public double Percent { get; init; }
    }


    public readonly struct CompositionInfo
    {
        [JsonProperty("Ice")]
        public double Ice { get; init; }

        [JsonProperty("Rock")]
        public double Rock { get; init; }

        [JsonProperty("Metal")]
        public double Metal { get; init; }
    }
}