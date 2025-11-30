using System.Collections.Generic;
using System.Linq;
using EliteAPI.Exobiology.Data;
using EliteAPI.Exobiology.Models;

namespace EliteAPI.Exobiology.Calculators;

/// <summary>
/// Calculates potential exobiology credits from scanning biological species.
/// </summary>
public static class ExobiologyWorthCalculator
{
    /// <summary>
    /// Multiplier for completed species scans (3/3 samples).
    /// Note: This is approximate - actual values vary by scan level:
    /// - First scan (Log): ~20% of base
    /// - Second scan (Sample): ~40% of base
    /// - Third scan (Analyze): Full base value
    /// Total: approximately 1.6x base for all 3 scans combined
    /// </summary>
    private const float ScanMultiplier = 1.6f;

    /// <summary>
    /// Predicts which species could spawn on the given planet based on its properties.
    /// </summary>
    public static List<SpeciesPrediction> PredictSpecies(PlanetContext context)
    {
        var possibleSpecies = SpeciesSpawnConditions.GetPossibleSpecies(context);

        return possibleSpecies.Select(species => new SpeciesPrediction
        {
            Species = species,
            BaseValue = species.GetBaseValue(),
            EstimatedValue = (long)(species.GetBaseValue() * ScanMultiplier)
        }).ToList();
    }

    /// <summary>
    /// Calculates total potential exobiology value for a planet.
    /// </summary>
    public static ExobiologyValue CalculateExobiologyValue(PlanetContext context)
    {
        var predictions = PredictSpecies(context);

        return new ExobiologyValue
        {
            PossibleSpecies = predictions,
            MinimumValue = predictions.Count > 0 ? predictions.Min(p => p.EstimatedValue) : 0,
            MaximumValue = predictions.Sum(p => p.EstimatedValue),
            AverageValue = predictions.Count > 0 ? (long)predictions.Average(p => p.EstimatedValue) : 0,
            SpeciesCount = predictions.Count
        };
    }

    /// <summary>
    /// Calculates value based on known biological signals from FSS or SAA scan.
    /// </summary>
    public static ExobiologyValue CalculateExobiologyValueFromSignals(
        PlanetContext context,
        int knownBiologicalSignals)
    {
        var predictions = PredictSpecies(context);

        // If we know the exact number of signals, we can be more precise
        if (knownBiologicalSignals > 0 && predictions.Count >= knownBiologicalSignals)
        {
            // Take the top N most valuable species
            var topSpecies = predictions
                .OrderByDescending(p => p.EstimatedValue)
                .Take(knownBiologicalSignals)
                .ToList();

            return new ExobiologyValue
            {
                PossibleSpecies = topSpecies,
                MinimumValue = topSpecies.Sum(p => p.EstimatedValue),
                MaximumValue = topSpecies.Sum(p => p.EstimatedValue),
                AverageValue = topSpecies.Sum(p => p.EstimatedValue),
                SpeciesCount = topSpecies.Count
            };
        }

        // If we have biological signals but no matching species predictions,
        // return the signal count but no credit estimates
        if (knownBiologicalSignals > 0 && predictions.Count == 0)
        {
            return new ExobiologyValue
            {
                PossibleSpecies = new List<SpeciesPrediction>(),
                MinimumValue = 0,
                MaximumValue = 0,
                AverageValue = 0,
                SpeciesCount = knownBiologicalSignals
            };
        }

        return CalculateExobiologyValue(context);
    }
}

/// <summary>
/// Prediction for a single species that may spawn on a planet.
/// </summary>
public class SpeciesPrediction
{
    /// <summary>The species that may spawn</summary>
    public Species Species { get; set; }

    /// <summary>Base value for fully scanning this species (3/3 scans)</summary>
    public long BaseValue { get; set; }

    /// <summary>Estimated value including scan multipliers</summary>
    public long EstimatedValue { get; set; }

    public override string ToString()
    {
        return $"{Species}: {EstimatedValue:N0} cr";
    }
}

/// <summary>
/// Breakdown of potential exobiology values for a planetary body.
/// </summary>
public class ExobiologyValue
{
    /// <summary>List of species that could potentially spawn</summary>
    public List<SpeciesPrediction> PossibleSpecies { get; set; } = new();

    /// <summary>Minimum expected value (best case, fewest species)</summary>
    public long MinimumValue { get; set; }

    /// <summary>Maximum expected value (if all predicted species are present)</summary>
    public long MaximumValue { get; set; }

    /// <summary>Average expected value</summary>
    public long AverageValue { get; set; }

    /// <summary>Number of possible species</summary>
    public int SpeciesCount { get; set; }

    public override string ToString()
    {
        if (SpeciesCount == 0)
            return "No biological species predicted";

        if (MinimumValue == MaximumValue)
            return $"{SpeciesCount} species, {MaximumValue:N0} cr total";

        return $"{SpeciesCount} possible species, {MinimumValue:N0} - {MaximumValue:N0} cr";
    }
}
