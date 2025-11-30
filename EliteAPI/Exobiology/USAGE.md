# EliteAPI.Exobiology Usage Guide

## System Tracker - Recommended Approach

The `SystemTracker` manages state across multiple events, building up complete planet data as you scan a system.

### Full Example with System Tracking

```csharp
using EliteAPI;
using EliteAPI.Exobiology;
using EliteAPI.Events.Game;

var api = EliteDangerousApi.Create();
var tracker = new SystemTracker();

// Track system changes
api.Events.On<FsdJumpEvent>((jump, ctx) =>
{
    tracker.OnSystemChanged(jump.StarSystem);
    Console.WriteLine($"Jumped to {jump.StarSystem}");
});

// Process scan events
api.Events.On<ScanEvent>((scan, ctx) =>
{
    var body = tracker.OnScan(scan);

    // Get preliminary worth estimate (may improve with more data)
    var worth = body.GetWorth();
    if (worth != null && worth.BiologicalSignals > 0)
    {
        Console.WriteLine($"{scan.BodyName}: {worth.BiologicalSignals} bio signals");
    }
});

// Add FSS signal data
api.Events.On<FSSBodySignalsEvent>((signals, ctx) =>
{
    var body = tracker.OnFSSBodySignals(signals);

    // Now we know how many biological signals
    var worth = body?.GetWorth();
    if (worth != null)
    {
        Console.WriteLine($"\n{signals.BodyName} FSS Complete:");
        Console.WriteLine($"  Biological Signals: {worth.BiologicalSignals}");
        Console.WriteLine($"  Estimated Worth: {worth.MaximumTotalValue:N0} cr");
    }
});

// Add SAA (DSS) data
api.Events.On<SAASignalsFoundEvent>((signals, ctx) =>
{
    var body = tracker.OnSAASignalsFound(signals);

    // Now we have genus information
    var worth = body?.GetWorth();
    if (worth != null)
    {
        Console.WriteLine($"\n{signals.BodyName} DSS Complete:");
        Console.WriteLine(worth.GetFormattedSummary());
    }
});

// Show summary of worthwhile bodies when done scanning
api.Events.On<FSSSignalDiscoveredEvent>((signal, ctx) =>
{
    // When you discover the last signal, show summary
    var worthwhile = tracker.GetWorthwhileBodies(minimumCredits: 5_000_000);

    if (worthwhile.Count > 0)
    {
        Console.WriteLine("\n═══ WORTHWHILE BODIES IN SYSTEM ═══");
        foreach (var body in worthwhile)
        {
            Console.WriteLine($"{body.BodyName}: {body.MaximumTotalValue:N0} cr");
        }
    }
});

api.Start();
```

### How Data Accumulates

1. **ScanEvent** → Basic planet properties (temperature, gravity, atmosphere, etc.)
2. **FSSBodySignalsEvent** → Number of biological signals detected
3. **SAASignalsFoundEvent** → Specific genera after DSS mapping

The `SystemTracker` combines all three automatically:

```csharp
var tracker = new SystemTracker();

// Event 1: Scan gives us planet properties
var body = tracker.OnScan(scanEvent);
// body.Context now has: temperature, gravity, atmosphere, etc.
// Worth estimate: Based on predicted species from conditions

// Event 2: FSS tells us there are 3 biological signals
body = tracker.OnFSSBodySignals(fssEvent);
// body.Context updated with: BiologicalSignals = 3
// Worth estimate: Top 3 predicted species

// Event 3: SAA tells us specific genera
body = tracker.OnSAASignalsFound(saaEvent);
// body.Context updated with: exact genus count
// Worth estimate: Most accurate prediction
```

### Filtering Worthwhile Bodies

```csharp
// Get all bodies worth > 5 million credits
var worthwhile = tracker.GetWorthwhileBodies(minimumCredits: 5_000_000);

foreach (var body in worthwhile)
{
    Console.WriteLine($"✓ {body.BodyName}");
    Console.WriteLine($"  Exobiology: {body.ExobiologyValue.MaximumValue:N0} cr");
    Console.WriteLine($"  Exploration: {body.TotalExplorationValue:N0} cr");
    Console.WriteLine($"  TOTAL: {body.MaximumTotalValue:N0} cr\n");
}
```

### Checking Individual Bodies

```csharp
// Get specific body
var body = tracker.GetBody("Praea Euq AA-A h0 3 a");

if (body != null && body.HasFullScanData)
{
    Console.WriteLine($"Has full scan: {body.HasFullScanData}");
    Console.WriteLine($"Has FSS data: {body.HasFSSData}");

    var worth = body.GetWorth();
    Console.WriteLine(worth?.GetFormattedSummary());
}
```

### System-Wide Analysis

```csharp
// After scanning entire system
var allBodies = tracker.GetAllBodiesWorth();

Console.WriteLine($"Total bodies scanned: {allBodies.Count}");
Console.WriteLine($"Total system value: {allBodies.Sum(b => b.MaximumTotalValue):N0} cr");

// Bodies sorted by value (highest first)
foreach (var body in allBodies.Take(5))
{
    Console.WriteLine($"{body.BodyName}: {body.MaximumTotalValue:N0} cr");
}
```

## Simple One-Shot Usage (Without Tracker)

If you only want to analyze a single scan without tracking:

```csharp
api.Events.On<ScanEvent>((scan, ctx) =>
{
    // Quick conversion
    var planetContext = PlanetContextBuilder.FromScan(scan);

    // Calculate worth
    var worth = PlanetWorthCalculator.CalculateWorth(planetContext);

    // Display
    if (worth.MaximumTotalValue > 1_000_000)
    {
        Console.WriteLine(worth.GetFormattedSummary());
    }
});
```

## Understanding Worth Values

```csharp
var worth = tracker.GetBodyWorth("Planet A 1");

// FSS value (just discovering the body)
Console.WriteLine($"FSS: {worth.FSSValue:N0} cr");

// DSS value (detailed surface scan / mapping)
Console.WriteLine($"DSS: {worth.DSSValue:N0} cr");

// First footfall (if you land first)
Console.WriteLine($"Footfall: {worth.FirstFootfallBonus:N0} cr");

// Exobiology (scanning all species 3 times each)
Console.WriteLine($"Bio Species: {worth.ExobiologyValue.SpeciesCount}");
Console.WriteLine($"Bio Value: {worth.ExobiologyValue.MaximumValue:N0} cr");

// Total potential
Console.WriteLine($"TOTAL: {worth.MaximumTotalValue:N0} cr");
```

## Working with Predictions

```csharp
var context = PlanetContextBuilder.FromScan(scanEvent);

// Get species predictions
var predictions = ExobiologyWorthCalculator.PredictSpecies(context);

foreach (var prediction in predictions)
{
    Console.WriteLine($"{prediction.Species}:");
    Console.WriteLine($"  Base value: {prediction.BaseValue:N0} cr");
    Console.WriteLine($"  Estimated (with scans): {prediction.EstimatedValue:N0} cr");
}

// Or get full exobiology value breakdown
var bioValue = ExobiologyWorthCalculator.CalculateExobiologyValue(context);

Console.WriteLine($"Possible species: {bioValue.SpeciesCount}");
Console.WriteLine($"Min value: {bioValue.MinimumValue:N0} cr");
Console.WriteLine($"Max value: {bioValue.MaximumValue:N0} cr");
```

## Tips

1. **Always use SystemTracker** for real-time scanning - it handles state management automatically
2. **Check `HasFullScanData`** before making decisions - partial data gives less accurate predictions
3. **BiologicalSignals count matters** - knowing "3 signals" lets you pick top 3 predicted species
4. **System-wide conditions are important** - some species only spawn if the system contains specific body types (e.g., Earth-like worlds)
5. **First discoveries are worth a lot** - `WasDiscovered = false` means 9.6x multiplier on DSS value
