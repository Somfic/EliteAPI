using System.Collections.Generic;

namespace EliteAPI.Exobiology.Models;

/// <summary>
/// Contains all the information about a planet needed to evaluate spawn conditions.
/// Populated from ScanEvent data.
/// </summary>
public class PlanetContext
{
    // Basic properties
    public string BodyName { get; set; } = string.Empty;
    public string BodyID { get; set; } = string.Empty;
    public PlanetClass? PlanetClass { get; set; }
    public double SurfaceTemperature { get; set; }
    public double Gravity { get; set; } // In G
    public double SurfacePressure { get; set; } // In atmospheres
    public double DistanceFromArrivalLS { get; set; }

    // Atmosphere
    public AtmosphereType? Atmosphere { get; set; }
    public bool IsThinAtmosphere { get; set; }

    // Volcanism
    public VolcanismType? Volcanism { get; set; }

    // Composition
    public float? CompositionIce { get; set; }
    public float? CompositionRock { get; set; }
    public float? CompositionMetal { get; set; }

    // Stars
    public StarClass? MainStarClass { get; set; }
    public StarClass? ParentStarClass { get; set; }
    public StarLuminosity? ParentStarLuminosity { get; set; }

    // System information
    public HashSet<PlanetClass>? SystemBodiesContain { get; set; }
    public bool HasGeologicalSignals { get; set; }
    public int? RegionID { get; set; } // Elite Dangerous galactic region ID (1-42)

    // Biological signals
    public int BiologicalSignals { get; set; }

    // Discovery status
    public bool WasDiscovered { get; set; }
    public bool WasMapped { get; set; }
    public bool IsLandable { get; set; }

    // Mass for value calculations
    public double MassEM { get; set; } // Earth masses
    public bool IsTerraformable { get; set; }
}
