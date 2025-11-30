using System;
using EliteAPI.Exobiology.Models;

namespace EliteAPI.Exobiology.Calculators;

/// <summary>
/// Calculates exploration credits for scanning celestial bodies.
/// Based on Elite Dangerous scanning formulas (as of Odyssey Update 18).
/// </summary>
public static class ExplorationWorthCalculator
{
    /// <summary>
    /// Calculates the estimated worth of scanning a star.
    /// </summary>
    /// <param name="starClass">The star's classification</param>
    /// <param name="stellarMass">The star's mass in solar masses</param>
    /// <param name="isFirstDiscovery">Whether this is a first discovery</param>
    /// <returns>Credits earned from scanning</returns>
    public static long CalculateStarWorth(StarClass starClass, double stellarMass, bool isFirstDiscovery)
    {
        var baseValue = starClass.GetBaseValue();
        var massFactor = (float)Math.Max(stellarMass, 1.0);
        var bodyValue = baseValue + massFactor * baseValue / 66.25f;

        if (isFirstDiscovery)
        {
            bodyValue *= 2.6f;
        }

        return (long)bodyValue;
    }

    /// <summary>
    /// Calculates the estimated worth of scanning a planet.
    /// </summary>
    /// <param name="context">The planet context with all scanning data</param>
    /// <returns>Credits earned from scanning</returns>
    public static long CalculatePlanetWorth(PlanetContext context)
    {
        if (!context.PlanetClass.HasValue)
            return 0;

        var baseValue = context.PlanetClass.Value.GetBaseValue();
        var terraformableBonus = context.IsTerraformable
            ? context.PlanetClass.Value.GetTerraformableBonus()
            : 0;

        var scanValue = (float)(baseValue + terraformableBonus);
        var massFactor = (float)Math.Max(context.MassEM, 1.0);

        // Elite Dangerous formula: baseValue * (1 + mass^0.2 * 0.56591828)
        var bodyValue = Math.Max(
            scanValue + scanValue * (float)Math.Pow(massFactor, 0.2) * 0.56591828f,
            500f
        );

        // Apply discovery/mapping multipliers
        float multiplier = (context.WasDiscovered, context.WasMapped) switch
        {
            (false, false) => 9.619019f,    // First discovery + first map
            (true, false) => 8.0956f,        // First map only
            _ => 3.3333333f                  // Already discovered and mapped
        };

        return (long)(bodyValue * multiplier);
    }

    /// <summary>
    /// Estimates first footfall bonus value.
    /// First footfall gives approximately 50% of the scan value.
    /// </summary>
    public static long EstimateFirstFootfallBonus(PlanetContext context)
    {
        if (!context.IsLandable)
            return 0;

        // Assume first footfall if not discovered
        if (!context.WasDiscovered)
        {
            var scanValue = CalculatePlanetWorth(context);
            return (long)(scanValue * 0.5);
        }

        // Conservative estimate if already discovered
        return 0;
    }

    /// <summary>
    /// Calculates the Full Spectrum Scan (FSS) value - basic discovery scan.
    /// This is the value for honking + FSS scanning without mapping.
    /// </summary>
    public static long CalculateFSSValue(PlanetContext context)
    {
        if (!context.PlanetClass.HasValue)
            return 0;

        var baseValue = context.PlanetClass.Value.GetBaseValue();
        var terraformableBonus = context.IsTerraformable
            ? context.PlanetClass.Value.GetTerraformableBonus()
            : 0;

        var scanValue = (float)(baseValue + terraformableBonus);
        var massFactor = (float)Math.Max(context.MassEM, 1.0);

        // Elite Dangerous formula: baseValue * (1 + mass^0.2 * 0.56591828)
        var bodyValue = Math.Max(
            scanValue + scanValue * (float)Math.Pow(massFactor, 0.2) * 0.56591828f,
            500f
        );

        // FSS value is base value with first discovery multiplier (if applicable)
        // No mapping multiplier - just 2.6x for first discovery OR 1x if already discovered
        float multiplier = context.WasDiscovered ? 1.0f : 2.6f;

        return (long)(bodyValue * multiplier);
    }

    /// <summary>
    /// Calculates the Detailed Surface Scanner (DSS) value - full mapping value.
    /// This is the TOTAL value including discovery + mapping bonuses.
    /// This REPLACES the FSS value, not adds to it.
    /// </summary>
    public static long CalculateDSSValue(PlanetContext context)
    {
        return CalculatePlanetWorth(context);
    }

    /// <summary>
    /// Calculates total potential exploration value (FSS + DSS + First Footfall).
    /// </summary>
    public static ExplorationValue CalculateTotalExplorationValue(PlanetContext context)
    {
        return new ExplorationValue
        {
            FSSValue = CalculateFSSValue(context),
            DSSValue = CalculateDSSValue(context),
            FirstFootfallBonus = EstimateFirstFootfallBonus(context),
        };
    }
}

/// <summary>
/// Breakdown of exploration values for a planetary body.
/// </summary>
public class ExplorationValue
{
    /// <summary>Full Spectrum Scan value (basic discovery)</summary>
    public long FSSValue { get; set; }

    /// <summary>Detailed Surface Scan value (includes mapping bonus)</summary>
    public long DSSValue { get; set; }

    /// <summary>First footfall bonus (if landing on undiscovered planet)</summary>
    public long FirstFootfallBonus { get; set; }

    /// <summary>Total exploration value</summary>
    public long TotalValue => FSSValue + DSSValue + FirstFootfallBonus;
}
