using System;
using EliteAPI.Exobiology.Models;

namespace EliteAPI.Exobiology.Calculators;

/// <summary>
/// Main calculator that determines if a planet is worth scanning.
/// Combines exploration value (FSS/DSS/Footfall) and exobiology value.
/// </summary>
public static class PlanetWorthCalculator
{
    /// <summary>
    /// Calculates the complete worth breakdown for a planet.
    /// </summary>
    public static PlanetWorthSummary CalculateWorth(PlanetContext context)
    {
        var exploration = ExplorationWorthCalculator.CalculateTotalExplorationValue(context);

        // Use signal count if available, otherwise predict from planet properties
        var exobiology = context.BiologicalSignals > 0
            ? ExobiologyWorthCalculator.CalculateExobiologyValueFromSignals(context, context.BiologicalSignals)
            : ExobiologyWorthCalculator.CalculateExobiologyValue(context);

        return new PlanetWorthSummary
        {
            BodyName = context.BodyName,
            PlanetClass = context.PlanetClass,
            BiologicalSignals = context.BiologicalSignals,

            // Exploration values
            FSSValue = exploration.FSSValue,
            DSSValue = exploration.DSSValue,
            FirstFootfallBonus = exploration.FirstFootfallBonus,

            // Exobiology
            ExobiologyValue = exobiology,

            // Discovery status
            WasDiscovered = context.WasDiscovered,
            WasMapped = context.WasMapped,
            IsLandable = context.IsLandable
        };
    }

    /// <summary>
    /// Calculates worth with known biological signal count from FSS or SAA scan.
    /// </summary>
    public static PlanetWorthSummary CalculateWorthWithSignals(PlanetContext context, int biologicalSignals)
    {
        var exploration = ExplorationWorthCalculator.CalculateTotalExplorationValue(context);
        var exobiology = ExobiologyWorthCalculator.CalculateExobiologyValueFromSignals(context, biologicalSignals);

        return new PlanetWorthSummary
        {
            BodyName = context.BodyName,
            PlanetClass = context.PlanetClass,
            BiologicalSignals = biologicalSignals,

            FSSValue = exploration.FSSValue,
            DSSValue = exploration.DSSValue,
            FirstFootfallBonus = exploration.FirstFootfallBonus,

            ExobiologyValue = exobiology,

            WasDiscovered = context.WasDiscovered,
            WasMapped = context.WasMapped,
            IsLandable = context.IsLandable
        };
    }

    /// <summary>
    /// Determines if a planet is worth scanning based on a credit threshold.
    /// </summary>
    public static bool IsWorthScanning(PlanetWorthSummary summary, long minimumCredits = 1_000_000)
    {
        return summary.MaximumTotalValue >= minimumCredits;
    }
}

/// <summary>
/// Complete worth summary for a planetary body.
/// </summary>
public class PlanetWorthSummary
{
    public string BodyName { get; set; } = string.Empty;
    public PlanetClass? PlanetClass { get; set; }
    public int BiologicalSignals { get; set; }

    // Exploration - FSS only (no mapping)
    public long FSSValue { get; set; }

    // Exploration - DSS mapped value
    public long DSSValue { get; set; }

    // Exploration - First footfall
    public long FirstFootfallBonus { get; set; }

    // Calculated exploration totals
    // Note: DSSValue already includes the discovery value, so we don't add FSSValue to it
    public long ExplorationValueNotMapped => FSSValue + FirstFootfallBonus;
    public long ExplorationValueMapped => DSSValue + FirstFootfallBonus;
    public long TotalExplorationValue => ExplorationValueMapped;

    // Exobiology
    public ExobiologyValue ExobiologyValue { get; set; } = new();

    // Total value ranges (exploration + exobiology)
    public long MinimumTotalValue => TotalExplorationValue + ExobiologyValue.MinimumValue;
    public long MaximumTotalValue => TotalExplorationValue + ExobiologyValue.MaximumValue;
    public long AverageTotalValue => TotalExplorationValue + ExobiologyValue.AverageValue;

    // Non-mapped total values (FSS only, no DSS)
    public long MinimumTotalValueNotMapped => ExplorationValueNotMapped + ExobiologyValue.MinimumValue;
    public long MaximumTotalValueNotMapped => ExplorationValueNotMapped + ExobiologyValue.MaximumValue;
    public long AverageTotalValueNotMapped => ExplorationValueNotMapped + ExobiologyValue.AverageValue;

    // Mapped total values (FSS + DSS)
    public long MinimumTotalValueMapped => ExplorationValueMapped + ExobiologyValue.MinimumValue;
    public long MaximumTotalValueMapped => ExplorationValueMapped + ExobiologyValue.MaximumValue;
    public long AverageTotalValueMapped => ExplorationValueMapped + ExobiologyValue.AverageValue;

    // Status
    public bool WasDiscovered { get; set; }
    public bool WasMapped { get; set; }
    public bool IsLandable { get; set; }

    /// <summary>
    /// Gets a formatted summary string for console output.
    /// </summary>
    public string GetFormattedSummary()
    {
        var summary = $@"
═══════════════════════════════════════════════════════
Planet: {BodyName}
Class: {PlanetClass}
Biological Signals: {BiologicalSignals}
═══════════════════════════════════════════════════════

EXPLORATION VALUE:
  FSS (Discovery):     {FSSValue,15:N0} cr {(WasDiscovered ? "(already discovered)" : "(first discovery!)")}
  DSS (Mapping):       {DSSValue,15:N0} cr {(WasMapped ? "(already mapped)" : "(first map!)")}
  First Footfall:      {FirstFootfallBonus,15:N0} cr {(IsLandable ? (FirstFootfallBonus > 0 ? "(estimated)" : "(assumed touched)") : "(not landable)")}
                       ―――――――――――――――――――
  Not Mapped Total:    {ExplorationValueNotMapped,15:N0} cr
  Mapped Total:        {ExplorationValueMapped,15:N0} cr

EXOBIOLOGY VALUE:
  Possible Species: {ExobiologyValue.SpeciesCount}
";

        if (ExobiologyValue.SpeciesCount > 0)
        {
            summary += "  Predicted Species:\n";
            foreach (var species in ExobiologyValue.PossibleSpecies)
            {
                summary += $"    • {species.Species,-30} {species.EstimatedValue,12:N0} cr\n";
            }
            summary += $"                       ―――――――――――――――――――\n";
            summary += $"  Min Bio Value:       {ExobiologyValue.MinimumValue,15:N0} cr\n";
            summary += $"  Max Bio Value:       {ExobiologyValue.MaximumValue,15:N0} cr\n";
            summary += $"  Avg Bio Value:       {ExobiologyValue.AverageValue,15:N0} cr\n";
        }
        else
        {
            summary += "  No biological species predicted\n";
        }

        summary += $@"
═══════════════════════════════════════════════════════
TOTAL VALUE (NOT MAPPED):
  Min: {MinimumTotalValueNotMapped,15:N0} cr  Max: {MaximumTotalValueNotMapped,15:N0} cr  Avg: {AverageTotalValueNotMapped,15:N0} cr

TOTAL VALUE (MAPPED):
  Min: {MinimumTotalValueMapped,15:N0} cr  Max: {MaximumTotalValueMapped,15:N0} cr  Avg: {AverageTotalValueMapped,15:N0} cr
═══════════════════════════════════════════════════════

VERDICT: {GetVerdict()}
";

        return summary;
    }

    private string GetVerdict()
    {
        if (MaximumTotalValue >= 50_000_000)
            return "✓✓✓ EXTREMELY VALUABLE - Definitely worth it!";
        if (MaximumTotalValue >= 20_000_000)
            return "✓✓ VERY VALUABLE - Highly recommended!";
        if (MaximumTotalValue >= 5_000_000)
            return "✓ WORTH IT - Good credits";
        if (MaximumTotalValue >= 1_000_000)
            return "~ MODERATE - Decent credits";

        return "✗ LOW VALUE - Consider skipping unless exploring";
    }

    public override string ToString() => GetFormattedSummary();
}
