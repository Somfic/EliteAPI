using System.Collections.Generic;
using System.Linq;

namespace EliteAPI.Exobiology.Models;

/// <summary>
/// Represents a condition that must be met for a species to spawn on a planetary body.
/// Conditions can be combined using All (AND) and Any (OR) logic.
/// </summary>
public abstract class SpawnCondition
{
    /// <summary>
    /// Evaluates whether this condition is met for the given planet context.
    /// </summary>
    public abstract bool IsMet(PlanetContext context);

    // Temperature conditions
    public class MinTemperature : SpawnCondition
    {
        public float Value { get; }
        public MinTemperature(float value) => Value = value;
        public override bool IsMet(PlanetContext context) => context.SurfaceTemperature >= Value;
    }

    public class MaxTemperature : SpawnCondition
    {
        public float Value { get; }
        public MaxTemperature(float value) => Value = value;
        public override bool IsMet(PlanetContext context) => context.SurfaceTemperature <= Value;
    }

    // Gravity conditions (in G)
    public class MinGravity : SpawnCondition
    {
        public float Value { get; }
        public MinGravity(float value) => Value = value;
        public override bool IsMet(PlanetContext context) => context.Gravity >= Value;
    }

    public class MaxGravity : SpawnCondition
    {
        public float Value { get; }
        public MaxGravity(float value) => Value = value;
        public override bool IsMet(PlanetContext context) => context.Gravity <= Value;
    }

    // Pressure conditions (atmospheres)
    public class MinPressure : SpawnCondition
    {
        public float Value { get; }
        public MinPressure(float value) => Value = value;
        public override bool IsMet(PlanetContext context) => context.SurfacePressure >= Value;
    }

    public class MaxPressure : SpawnCondition
    {
        public float Value { get; }
        public MaxPressure(float value) => Value = value;
        public override bool IsMet(PlanetContext context) => context.SurfacePressure <= Value;
    }

    // Atmosphere conditions
    public class NoAtmosphere : SpawnCondition
    {
        public override bool IsMet(PlanetContext context) => context.Atmosphere == AtmosphereType.None;
    }

    public class RequiresAtmosphere : SpawnCondition
    {
        public List<AtmosphereType> AtmosphereTypes { get; }
        public RequiresAtmosphere(params AtmosphereType[] types) => AtmosphereTypes = new List<AtmosphereType>(types);
        public override bool IsMet(PlanetContext context) => context.Atmosphere.HasValue && AtmosphereTypes.Contains(context.Atmosphere.Value);
    }

    public class ThinAtmosphere : SpawnCondition
    {
        public AtmosphereType AtmosphereType { get; }
        public ThinAtmosphere(AtmosphereType type) => AtmosphereType = type;
        public override bool IsMet(PlanetContext context) =>
            context.Atmosphere == AtmosphereType && context.IsThinAtmosphere;
    }

    public class AnyThinAtmosphere : SpawnCondition
    {
        public override bool IsMet(PlanetContext context) => context.IsThinAtmosphere;
    }

    // Planet class condition
    public class RequiresPlanetClass : SpawnCondition
    {
        public List<PlanetClass> PlanetClasses { get; }
        public RequiresPlanetClass(params PlanetClass[] planetClasses) => PlanetClasses = new List<PlanetClass>(planetClasses);
        public override bool IsMet(PlanetContext context) => context.PlanetClass.HasValue && PlanetClasses.Contains(context.PlanetClass.Value);
    }

    // Volcanism conditions
    public class RequiresVolcanism : SpawnCondition
    {
        public List<VolcanismType> VolcanismTypes { get; }
        public RequiresVolcanism(params VolcanismType[] types) => VolcanismTypes = new List<VolcanismType>(types);
        public override bool IsMet(PlanetContext context) => context.Volcanism.HasValue && VolcanismTypes.Contains(context.Volcanism.Value);
    }

    public class NoVolcanism : SpawnCondition
    {
        public override bool IsMet(PlanetContext context) => !context.Volcanism.HasValue || context.Volcanism == VolcanismType.None;
    }

    public class AnyVolcanism : SpawnCondition
    {
        public override bool IsMet(PlanetContext context) =>
            context.Volcanism.HasValue && context.Volcanism != VolcanismType.None;
    }

    // Star class conditions
    public class ParentStarClass : SpawnCondition
    {
        public List<StarClass> StarClasses { get; }
        public ParentStarClass(params StarClass[] starClasses) => StarClasses = new List<StarClass>(starClasses);
        public override bool IsMet(PlanetContext context) => context.ParentStarClass.HasValue && StarClasses.Contains(context.ParentStarClass.Value);
    }

    public class MainStarClass : SpawnCondition
    {
        public List<StarClass> StarClasses { get; }
        public MainStarClass(params StarClass[] starClasses) => StarClasses = new List<StarClass>(starClasses);
        public override bool IsMet(PlanetContext context) => context.MainStarClass.HasValue && StarClasses.Contains(context.MainStarClass.Value);
    }

    /// <summary>
    /// Requires parent star to match a specific class and luminosity.
    /// </summary>
    public class ParentStarClassAndLuminosity : SpawnCondition
    {
        public StarClass StarClass { get; }
        public StarLuminosity Luminosity { get; }
        public ParentStarClassAndLuminosity(StarClass starClass, StarLuminosity luminosity)
        {
            StarClass = starClass;
            Luminosity = luminosity;
        }
        public override bool IsMet(PlanetContext context) =>
            context.ParentStarClass == StarClass && context.ParentStarLuminosity == Luminosity;
    }

    // Star luminosity conditions
    public class ParentStarLuminosity : SpawnCondition
    {
        public StarLuminosity Luminosity { get; }
        public ParentStarLuminosity(StarLuminosity luminosity) => Luminosity = luminosity;
        public override bool IsMet(PlanetContext context) => context.ParentStarLuminosity == Luminosity;
    }

    public class MinOrEqualParentStarLuminosity : SpawnCondition
    {
        public StarLuminosity Luminosity { get; }
        public MinOrEqualParentStarLuminosity(StarLuminosity luminosity) => Luminosity = luminosity;
        public override bool IsMet(PlanetContext context) =>
            context.ParentStarLuminosity.HasValue && (int)context.ParentStarLuminosity <= (int)Luminosity;
    }

    // System-wide conditions
    public class SystemContainsPlanetClass : SpawnCondition
    {
        public PlanetClass PlanetClass { get; }
        public SystemContainsPlanetClass(PlanetClass planetClass) => PlanetClass = planetClass;
        public override bool IsMet(PlanetContext context) =>
            context.SystemBodiesContain != null && context.SystemBodiesContain.Contains(PlanetClass);
    }

    public class GeologicalSignalsPresent : SpawnCondition
    {
        public override bool IsMet(PlanetContext context) => context.HasGeologicalSignals;
    }

    // Distance conditions
    public class MinDistanceFromParentSun : SpawnCondition
    {
        public float DistanceAU { get; }
        public MinDistanceFromParentSun(float distanceAU) => DistanceAU = distanceAU;
        public override bool IsMet(PlanetContext context) => context.DistanceFromArrivalLS >= DistanceAU;
    }

    // Composition conditions
    public class RockyComposition : SpawnCondition
    {
        public override bool IsMet(PlanetContext context) =>
            context.CompositionRock.HasValue && context.CompositionRock > 0.5f;
    }

    public class IcyComposition : SpawnCondition
    {
        public override bool IsMet(PlanetContext context) =>
            context.CompositionIce.HasValue && context.CompositionIce > 0.5f;
    }

    public class MetalComposition : SpawnCondition
    {
        public override bool IsMet(PlanetContext context) =>
            context.CompositionMetal.HasValue && context.CompositionMetal > 0.5f;
    }

    // Logical operators
    public class All : SpawnCondition
    {
        public List<SpawnCondition> Conditions { get; }
        public All(params SpawnCondition[] conditions) => Conditions = new List<SpawnCondition>(conditions);
        public All(List<SpawnCondition> conditions) => Conditions = conditions;
        public override bool IsMet(PlanetContext context) => Conditions.All(c => c.IsMet(context));
    }

    public class Any : SpawnCondition
    {
        public List<SpawnCondition> Conditions { get; }
        public Any(params SpawnCondition[] conditions) => Conditions = new List<SpawnCondition>(conditions);
        public Any(List<SpawnCondition> conditions) => Conditions = conditions;
        public override bool IsMet(PlanetContext context) => Conditions.Any(c => c.IsMet(context));
    }

    // Galactic region conditions
    public class RequiresRegion : SpawnCondition
    {
        public List<GalacticRegion> Regions { get; }
        public RequiresRegion(params GalacticRegion[] regions) => Regions = new List<GalacticRegion>(regions);
        public override bool IsMet(PlanetContext context) =>
            Regions.Any(region => GalacticRegionData.IsInRegion(context.RegionID, region));
    }

    public class NotInRegion : SpawnCondition
    {
        public List<GalacticRegion> Regions { get; }
        public NotInRegion(params GalacticRegion[] regions) => Regions = new List<GalacticRegion>(regions);
        public override bool IsMet(PlanetContext context) =>
            Regions.All(region => GalacticRegionData.IsNotInRegion(context.RegionID, region));
    }

    // Special conditions (nebula proximity, guardian sites, etc)
    public class Special : SpawnCondition
    {
        public string Description { get; }
        public Special(string description = "Special condition") => Description = description;
        public override bool IsMet(PlanetContext context) => false; // Always false for now
    }
}
