using System;
using EliteAPI.Events.Game;
using EliteAPI.Exobiology.Models;

namespace EliteAPI.Exobiology.Helpers;

/// <summary>
/// Builds a PlanetContext from EliteAPI scan events.
/// Can build incrementally as different event types provide additional data.
/// </summary>
public class PlanetContextBuilder
{
    private readonly PlanetContext _context;

    /// <summary>
    /// Creates a new builder with an empty context.
    /// </summary>
    public PlanetContextBuilder()
    {
        _context = new PlanetContext();
    }

    /// <summary>
    /// Creates a builder starting with an existing context.
    /// Use this to add data from additional events to an existing context.
    /// </summary>
    public PlanetContextBuilder(PlanetContext existingContext)
    {
        _context = existingContext;
    }

    /// <summary>
    /// Populates context from a ScanEvent.
    /// </summary>
    public PlanetContextBuilder FromScanEvent(ScanEvent scanEvent)
    {
        _context.BodyName = scanEvent.BodyName ?? "Unknown";
        _context.BodyID = scanEvent.BodyId ?? "";
        _context.SurfaceTemperature = scanEvent.SurfaceTemperature;
        _context.MassEM = scanEvent.MassEm;
        _context.DistanceFromArrivalLS = scanEvent.DistanceFromArrivalLs;
        _context.WasDiscovered = scanEvent.WasDiscovered;
        _context.WasMapped = scanEvent.WasMapped;
        _context.IsLandable = scanEvent.IsLandable;

        // Parse planet class
        _context.PlanetClass = PlanetClassExtensions.ParseFromJournal(scanEvent.PlanetClass);

        // Parse atmosphere
        var atmosphereJournal = scanEvent.AtmosphereType ?? scanEvent.Atmosphere;
        _context.Atmosphere = AtmosphereTypeExtensions.ParseFromJournal(atmosphereJournal);
        _context.IsThinAtmosphere = AtmosphereTypeExtensions.IsThinAtmosphere(atmosphereJournal);

        // Parse volcanism
        _context.Volcanism = VolcanismTypeExtensions.ParseFromJournal(scanEvent.Volcanism);

        // Convert gravity from m/s² to G
        if (scanEvent.SurfaceGravity > 0)
        {
            _context.Gravity = scanEvent.SurfaceGravity / 9.80665;
        }

        // Convert pressure from Pascals to atmospheres
        if (scanEvent.SurfacePressure > 0)
        {
            _context.SurfacePressure = scanEvent.SurfacePressure / 101325.0;
        }

        // Composition (if available)
        if (scanEvent.Composition.Ice > 0 || scanEvent.Composition.Rock > 0 || scanEvent.Composition.Metal > 0)
        {
            _context.CompositionIce = (float)scanEvent.Composition.Ice;
            _context.CompositionRock = (float)scanEvent.Composition.Rock;
            _context.CompositionMetal = (float)scanEvent.Composition.Metal;
        }

        // Terraformable status
        _context.IsTerraformable = !string.IsNullOrEmpty(scanEvent.TerraformState) &&
                                    scanEvent.TerraformState.IndexOf("Terraformable", StringComparison.OrdinalIgnoreCase) >= 0;

        return this;
    }

    /// <summary>
    /// Adds biological signal count from FSSBodySignalsEvent.
    /// </summary>
    public PlanetContextBuilder WithFSSBodySignals(FssBodySignalsEvent signalsEvent)
    {
        foreach (var signal in signalsEvent.Signals ?? Array.Empty<FssBodySignalsEvent.SignalInfo>())
        {
            var type = signal.Type.ToLowerInvariant();
            if (type.IndexOf("biological") >= 0 || type.IndexOf("$saa_signaltype_biological") >= 0)
            {
                _context.BiologicalSignals = (int)signal.Count;
                // If a planet has biological signals, it must be landable
                _context.IsLandable = true;
            }
            else if (type.IndexOf("geological") >= 0)
            {
                _context.HasGeologicalSignals = true;
            }
        }

        return this;
    }

    /// <summary>
    /// Adds biological signal count from SAASignalsFoundEvent.
    /// </summary>
    public PlanetContextBuilder WithSAASignals(SaaSignalsFoundEvent signalsEvent)
    {
        if (signalsEvent.Genuses != null && signalsEvent.Genuses.Count > 0)
        {
            _context.BiologicalSignals = signalsEvent.Genuses.Count;
            // If a planet has biological signals, it must be landable
            _context.IsLandable = true;
        }

        return this;
    }

    /// <summary>
    /// Sets the parent star information.
    /// </summary>
    public PlanetContextBuilder WithParentStar(StarClass? starClass, StarLuminosity? luminosity = null)
    {
        _context.ParentStarClass = starClass;
        _context.ParentStarLuminosity = luminosity;
        return this;
    }

    /// <summary>
    /// Sets the main (primary) star of the system.
    /// </summary>
    public PlanetContextBuilder WithMainStar(StarClass? starClass)
    {
        _context.MainStarClass = starClass;
        return this;
    }

    /// <summary>
    /// Builds the final PlanetContext.
    /// </summary>
    public PlanetContext Build() => _context;

    /// <summary>
    /// Quick conversion from ScanEvent to PlanetContext.
    /// </summary>
    public static PlanetContext FromScan(ScanEvent scanEvent)
    {
        return new PlanetContextBuilder()
            .FromScanEvent(scanEvent)
            .Build();
    }
}
