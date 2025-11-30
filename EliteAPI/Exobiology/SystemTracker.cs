using System.Collections.Generic;
using System.Linq;
using EliteAPI.Events.Game;
using EliteAPI.Exobiology.Calculators;
using EliteAPI.Exobiology.Helpers;
using EliteAPI.Exobiology.Models;

namespace EliteAPI.Exobiology;

/// <summary>
/// Tracks planetary bodies and their data across multiple journal events.
/// Accumulates information from Scan, FSSBodySignals, and SAASignalsFound events.
/// </summary>
public class SystemTracker
{
    private readonly Dictionary<string, TrackedBody> _bodies = new();
    private string? _currentSystem;
    private StarClass? _mainStarClass;
    private TrackedStar? _mainStar;

    /// <summary>
    /// Clears all tracked data when jumping to a new system.
    /// </summary>
    public void OnSystemChanged(string systemName)
    {
        if (_currentSystem != systemName)
        {
            _bodies.Clear();
            _currentSystem = systemName;
            _mainStarClass = null;
            _mainStar = null;
        }
    }

    /// <summary>
    /// Processes a Scan event and updates the tracked body data.
    /// </summary>
    public TrackedBody OnScan(ScanEvent scanEvent)
    {
        var bodyName = scanEvent.BodyName ?? "Unknown";

        // Determine if this is a star or planet
        var isMainStar = scanEvent.DistanceFromArrivalLs == 0.0 && !string.IsNullOrEmpty(scanEvent.StarType);

        // Track main star
        if (isMainStar)
        {
            _mainStarClass = StarClassExtensions.ParseFromJournal(scanEvent.StarType);
            _mainStar = new TrackedStar
            {
                StarClass = _mainStarClass,
                StellarMass = scanEvent.StellarMass > 0 ? scanEvent.StellarMass : 1.0,
                WasDiscovered = scanEvent.WasDiscovered
            };
        }

        // Get or create tracked body
        if (!_bodies.TryGetValue(bodyName, out var body))
        {
            body = new TrackedBody { BodyName = bodyName };
            _bodies[bodyName] = body;
        }

        // Build planet context from scan, preserving existing context if present
        var builder = body.Context != null
            ? new PlanetContextBuilder(body.Context)
            : new PlanetContextBuilder();

        body.Context = builder
            .FromScanEvent(scanEvent)
            .WithMainStar(_mainStarClass)
            .Build();

        // Update body list for system-wide checks
        UpdateSystemBodyList();

        return body;
    }

    /// <summary>
    /// Processes an FSSBodySignals event to add biological signal count.
    /// </summary>
    public TrackedBody? OnFSSBodySignals(FssBodySignalsEvent signalsEvent)
    {
        var bodyName = signalsEvent.BodyName ?? "Unknown";

        if (!_bodies.TryGetValue(bodyName, out var body))
        {
            // Create placeholder if we don't have scan data yet
            body = new TrackedBody
            {
                BodyName = bodyName,
                Context = new PlanetContext { BodyName = bodyName }
            };
            _bodies[bodyName] = body;
        }

        // Update context with signal data using existing context
        body.Context = new PlanetContextBuilder(body.Context ?? new PlanetContext { BodyName = bodyName })
            .WithFSSBodySignals(signalsEvent)
            .Build();

        return body;
    }

    /// <summary>
    /// Processes an SAASignalsFound event to add genus information.
    /// </summary>
    public TrackedBody? OnSAASignalsFound(SaaSignalsFoundEvent signalsEvent)
    {
        var bodyName = signalsEvent.BodyName ?? "Unknown";

        if (!_bodies.TryGetValue(bodyName, out var body))
        {
            body = new TrackedBody
            {
                BodyName = bodyName,
                Context = new PlanetContext { BodyName = bodyName }
            };
            _bodies[bodyName] = body;
        }

        // Update with SAA signal data using existing context
        body.Context = new PlanetContextBuilder(body.Context ?? new PlanetContext { BodyName = bodyName })
            .WithSAASignals(signalsEvent)
            .Build();

        return body;
    }

    /// <summary>
    /// Gets the current worth summary for a body.
    /// Returns null if the body hasn't been scanned yet.
    /// </summary>
    public PlanetWorthSummary? GetBodyWorth(string bodyName)
    {
        if (!_bodies.TryGetValue(bodyName, out var body) || body.Context == null)
            return null;

        return PlanetWorthCalculator.CalculateWorth(body.Context);
    }

    /// <summary>
    /// Gets worth summary for all tracked bodies in the current system.
    /// </summary>
    public List<PlanetWorthSummary> GetAllBodiesWorth()
    {
        return _bodies.Values
            .Where(b => b.Context != null)
            .Select(b => PlanetWorthCalculator.CalculateWorth(b.Context!))
            .OrderByDescending(w => w.MaximumTotalValue)
            .ToList();
    }

    /// <summary>
    /// Gets bodies that are worth scanning based on a credit threshold.
    /// </summary>
    public List<PlanetWorthSummary> GetWorthwhileBodies(long minimumCredits = 5_000_000)
    {
        return GetAllBodiesWorth()
            .Where(w => w.MaximumTotalValue >= minimumCredits)
            .ToList();
    }

    /// <summary>
    /// Gets a tracked body by name.
    /// </summary>
    public TrackedBody? GetBody(string bodyName)
    {
        _bodies.TryGetValue(bodyName, out var body);
        return body;
    }

    /// <summary>
    /// Gets all tracked bodies.
    /// </summary>
    public IEnumerable<TrackedBody> GetAllBodies() => _bodies.Values;

    /// <summary>
    /// Gets the main star value.
    /// </summary>
    public long GetMainStarValue()
    {
        if (_mainStar?.StarClass == null)
            return 0;

        return ExplorationWorthCalculator.CalculateStarWorth(
            _mainStar.StarClass.Value,
            _mainStar.StellarMass,
            !_mainStar.WasDiscovered
        );
    }

    /// <summary>
    /// Updates the system-wide body list used for spawn conditions.
    /// </summary>
    private void UpdateSystemBodyList()
    {
        var planetClasses = new HashSet<PlanetClass>(
            _bodies.Values
                .Select(b => b.Context?.PlanetClass)
                .Where(pc => pc.HasValue)
                .Select(pc => pc!.Value)
        );

        // Update all bodies with the system-wide planet class list
        foreach (var body in _bodies.Values.Where(b => b.Context != null))
        {
            body.Context!.SystemBodiesContain = planetClasses;
        }
    }
}

/// <summary>
/// Represents a tracked planetary body with accumulated data from multiple events.
/// </summary>
public class TrackedBody
{
    /// <summary>Body name from journal</summary>
    public string BodyName { get; set; } = string.Empty;

    /// <summary>Accumulated planet context data</summary>
    public PlanetContext? Context { get; set; }

    /// <summary>Whether we've received a full Scan event for this body</summary>
    public bool HasFullScanData => Context?.PlanetClass != null;

    /// <summary>Whether we've received FSS signal data</summary>
    public bool HasFSSData => Context?.BiologicalSignals > 0;

    /// <summary>Calculates the current worth based on available data</summary>
    public PlanetWorthSummary? GetWorth()
    {
        if (Context == null)
            return null;

        return PlanetWorthCalculator.CalculateWorth(Context);
    }
}

/// <summary>
/// Represents a tracked star.
/// </summary>
public class TrackedStar
{
    /// <summary>Star classification</summary>
    public StarClass? StarClass { get; set; }

    /// <summary>Stellar mass in solar masses</summary>
    public double StellarMass { get; set; }

    /// <summary>Whether the star was already discovered</summary>
    public bool WasDiscovered { get; set; }
}
