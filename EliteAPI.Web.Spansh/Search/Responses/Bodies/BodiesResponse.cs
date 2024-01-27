using EliteAPI.Web.Models;
using EliteAPI.Web.Spansh.Search.Requests;
using Newtonsoft.Json;

namespace EliteAPI.Web.Spansh.Search.Responses.Bodies;

public class BodiesResponse : IWebApiResponse
{
    [JsonProperty("count")]
    public long Count { get; init; }

    [JsonProperty("from")]
    public long From { get; init; }

    [JsonProperty("reference")]
    public SystemReference References { get; init; }

    [JsonProperty("results")]
    public IReadOnlyCollection<Body> Bodies { get; init; }

    [JsonProperty("search")]
    public BodiesRequest Search { get; init; }

    [JsonProperty("search_reference")]
    public string SearchReference { get; init; }

    [JsonProperty("size")]
    public long Size { get; init; }
}

public class SystemReference
{
    [JsonProperty("id64")]
    public long Id { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("x")]
    public long X { get; init; }

    [JsonProperty("y")]
    public long Y { get; init; }

    [JsonProperty("z")]
    public long Z { get; init; }
}

public class Body
{
    [JsonProperty("arg_of_periapsis")]
    public double ArgOfPeriapsis { get; init; }

    [JsonProperty("ascending_node")]
    public double AscendingNode { get; init; }

    [JsonProperty("atmosphere")]
    public string Atmosphere { get; init; }

    [JsonProperty("atmosphere_composition", NullValueHandling = NullValueHandling.Ignore)]
    public IReadOnlyCollection<AtmosphereComposition> AtmosphereComposition { get; init; }

    [JsonProperty("axis_tilt")]
    public double AxisTilt { get; init; }

    [JsonProperty("body_id")]
    public long BodyId { get; init; }

    [JsonProperty("distance")]
    public long Distance { get; init; }

    [JsonProperty("distance_to_arrival")]
    public double DistanceToArrival { get; init; }

    [JsonProperty("earth_masses")]
    public double EarthMasses { get; init; }

    [JsonProperty("estimated_mapping_value")]
    public long EstimatedMappingValue { get; init; }

    [JsonProperty("estimated_scan_value")]
    public long EstimatedScanValue { get; init; }

    [JsonProperty("gravity")]
    public double Gravity { get; init; }

    [JsonProperty("id")]
    public string Id { get; init; }

    [JsonProperty("id64")]
    public double Id64 { get; init; }

    [JsonProperty("is_landable")]
    public bool IsLandable { get; init; }

    [JsonProperty("is_main_star")]
    public object IsMainStar { get; init; }

    [JsonProperty("is_rotational_period_tidally_locked")]
    public bool IsRotationalPeriodTidallyLocked { get; init; }

    [JsonProperty("mean_anomaly")]
    public double MeanAnomaly { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("orbital_eccentricity")]
    public double OrbitalEccentricity { get; init; }

    [JsonProperty("orbital_inclination")]
    public double OrbitalInclination { get; init; }

    [JsonProperty("orbital_period")]
    public double OrbitalPeriod { get; init; }

    [JsonProperty("parents")]
    public IReadOnlyCollection<Parent> Parents { get; init; }

    [JsonProperty("radius")]
    public double Radius { get; init; }

    [JsonProperty("reserve_level", NullValueHandling = NullValueHandling.Ignore)]
    public string ReserveLevel { get; init; }

    [JsonProperty("rings", NullValueHandling = NullValueHandling.Ignore)]
    public IReadOnlyCollection<Ring> Rings { get; init; }

    [JsonProperty("rotational_period")]
    public double RotationalPeriod { get; init; }

    [JsonProperty("semi_major_axis")]
    public double SemiMajorAxis { get; init; }

    [JsonProperty("subtype")]
    public string Subtype { get; init; }

    [JsonProperty("surface_pressure")]
    public double SurfacePressure { get; init; }

    [JsonProperty("surface_temperature")]
    public double SurfaceTemperature { get; init; }

    [JsonProperty("system_id64")]
    public long SystemId64 { get; init; }

    [JsonProperty("system_name")]
    public string SystemName { get; init; }

    [JsonProperty("system_region")]
    public string SystemRegion { get; init; }

    [JsonProperty("system_x")]
    public long SystemX { get; init; }

    [JsonProperty("system_y")]
    public long SystemY { get; init; }

    [JsonProperty("system_z")]
    public long SystemZ { get; init; }

    [JsonProperty("terraforming_state")]
    public string TerraformingState { get; init; }

    [JsonProperty("type")]
    public string Type { get; init; }

    [JsonProperty("updated_at")]
    public string UpdatedAt { get; init; }

    [JsonProperty("landmark_value", NullValueHandling = NullValueHandling.Ignore)]
    public long? LandmarkValue { get; init; }

    [JsonProperty("landmarks", NullValueHandling = NullValueHandling.Ignore)]
    public IReadOnlyCollection<Landmark>? Landmarks { get; init; }

    [JsonProperty("materials", NullValueHandling = NullValueHandling.Ignore)]
    public IReadOnlyCollection<AtmosphereComposition>? Materials { get; init; }

    [JsonProperty("signal_count", NullValueHandling = NullValueHandling.Ignore)]
    public long? SignalCount { get; init; }

    [JsonProperty("signals", NullValueHandling = NullValueHandling.Ignore)]
    public IReadOnlyCollection<Signal>? Signals { get; init; }

    [JsonProperty("signals_updated_at", NullValueHandling = NullValueHandling.Ignore)]
    public string? SignalsUpdatedAt { get; init; }

    [JsonProperty("solid_composition", NullValueHandling = NullValueHandling.Ignore)]
    public IReadOnlyCollection<AtmosphereComposition>? SolidComposition { get; init; }

    [JsonProperty("stations", NullValueHandling = NullValueHandling.Ignore)]
    public IReadOnlyCollection<Station>? Stations { get; init; }

    [JsonProperty("volcanism_type", NullValueHandling = NullValueHandling.Ignore)]
    public string? VolcanismType { get; init; }
}

public class AtmosphereComposition
{
    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("share")]
    public double Share { get; init; }
}

public class Landmark
{
    [JsonProperty("id")]
    public long Id { get; init; }

    [JsonProperty("latitude")]
    public double Latitude { get; init; }

    [JsonProperty("longitude")]
    public double Longitude { get; init; }

    [JsonProperty("subtype")]
    public string Subtype { get; init; }

    [JsonProperty("type")]
    public string Type { get; init; }

    [JsonProperty("value")]
    public long Value { get; init; }
}

public class Parent
{
    [JsonProperty("id")]
    public long Id { get; init; }

    [JsonProperty("type")]
    public string Type { get; init; }
}

public class Ring
{
    [JsonProperty("inner_radius")]
    public long InnerRadius { get; init; }

    [JsonProperty("mass")]
    public long Mass { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("outer_radius")]
    public long OuterRadius { get; init; }

    [JsonProperty("type")]
    public string Type { get; init; }
}

public class Signal
{
    [JsonProperty("count")]
    public long Count { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }
}

public class Station
{
    [JsonProperty("distance_to_arrival")]
    public double DistanceToArrival { get; init; }

    [JsonProperty("has_large_pad")]
    public bool HasLargePad { get; init; }

    [JsonProperty("has_market")]
    public bool HasMarket { get; init; }

    [JsonProperty("large_pads")]
    public long LargePads { get; init; }

    [JsonProperty("market_id")]
    public long MarketId { get; init; }

    [JsonProperty("medium_pads")]
    public long MediumPads { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("small_pads")]
    public long SmallPads { get; init; }

    [JsonProperty("type")]
    public string Type { get; init; }
}
    