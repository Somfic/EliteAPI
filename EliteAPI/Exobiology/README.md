# EliteAPI.Exobiology

A C# library for calculating exploration and exobiology profit potential in Elite Dangerous. Now integrated into the main EliteAPI library.

## Features

- **System Tracker**: Manages state across multiple events (Scan, FSS, SAA)
- **Exploration Worth Calculator**: Calculates FSS, DSS, and first footfall values
- **Exobiology Prediction**: Predicts which biological species can spawn on a planet
- **Profit Analysis**: Determines if a planet is worth scanning based on total credit potential
- **EliteAPI Integration**: Works seamlessly with EliteAPI journal event parsing

## Quick Start

```csharp
using EliteAPI;
using EliteAPI.Exobiology;

var api = EliteDangerousApi.Create();
var tracker = new SystemTracker();

// Track system changes
api.Events.On<FsdJumpEvent>((jump, ctx) => tracker.OnSystemChanged(jump.StarSystem));

// Process scans
api.Events.On<ScanEvent>((scan, ctx) => tracker.OnScan(scan));

// Add FSS data
api.Events.On<FSSBodySignalsEvent>((signals, ctx) =>
{
    var body = tracker.OnFSSBodySignals(signals);
    var worth = body?.GetWorth();

    if (worth != null && worth.MaximumTotalValue > 5_000_000)
    {
        Console.WriteLine($"✓ {signals.BodyName}: {worth.MaximumTotalValue:N0} cr");
        Console.WriteLine($"  Species: {worth.ExobiologyValue.SpeciesCount}");
    }
});

api.Start();
```

**See [USAGE.md](USAGE.md) for detailed examples and best practices.**

## How It Works

### Multi-Event State Tracking

Elite Dangerous provides planet data across multiple events:

1. **ScanEvent** → Planet properties (temperature, gravity, atmosphere, etc.)
2. **FSSBodySignalsEvent** → Number of biological signals detected
3. **SAASignalsFoundEvent** → Specific genera after DSS mapping

The `SystemTracker` accumulates this data automatically:

```csharp
var tracker = new SystemTracker();

tracker.OnScan(scanEvent);               // Step 1: Basic properties
tracker.OnFSSBodySignals(fssEvent);      // Step 2: Signal count
tracker.OnSAASignalsFound(saaEvent);     // Step 3: Genera list

var worth = tracker.GetBodyWorth(bodyName);  // Complete analysis
```

### Exploration Worth Formulas

Uses Elite Dangerous' actual formulas (as of Odyssey Update 18):

- **FSS**: Discovery scan value based on planet class and mass
- **DSS**: Mapping bonus (8-9.6x multiplier depending on discovery status)
- **First Footfall**: ~50% bonus for being the first to land

### Exobiology Prediction

Evaluates planetary conditions against spawn requirements for 122 species:

- Temperature, gravity, pressure ranges
- Atmospheric composition (including "thin" variants)
- Volcanism type
- Planetary body class
- Parent/main star class and luminosity
- System-wide requirements (e.g., "must contain Earth-like world")

**Current Status**: 10 species implemented as examples. Remaining 112 need to be ported from:
`C:\Users\Lucas\ed-journals\src\modules\exobiology\static\species_spawn_conditions.rs`

## Example Output

```
═══════════════════════════════════════════════════════
Planet: Praea Euq AA-A h0 3 a
Class: RockyBody
Biological Signals: 3
═══════════════════════════════════════════════════════

EXPLORATION VALUE:
  FSS (Discovery):              2,430 cr (first discovery!)
  DSS (Mapping):               23,382 cr (first map!)
  First Footfall:              11,691 cr (estimated)
                       ―――――――――――――――――――
  Total Exploration:           37,503 cr

EXOBIOLOGY VALUE:
  Possible Species: 3
  Predicted Species:
    • BacteriumAurasus                  1,600,000 cr
    • BacteriumNebulus                  8,463,840 cr
    • AleoidaArcus                     11,604,000 cr
                       ―――――――――――――――――――
  Total Exobiology:            21,667,840 cr

═══════════════════════════════════════════════════════
TOTAL POTENTIAL VALUE:       21,705,343 cr
═══════════════════════════════════════════════════════

VERDICT: ✓✓ VERY VALUABLE - Highly recommended!
```

## API Overview

### SystemTracker (Recommended)

```csharp
var tracker = new SystemTracker();

// Event handlers
tracker.OnSystemChanged(systemName);
tracker.OnScan(scanEvent);
tracker.OnFSSBodySignals(signalsEvent);
tracker.OnSAASignalsFound(signalsEvent);

// Query results
var worth = tracker.GetBodyWorth(bodyName);
var worthwhile = tracker.GetWorthwhileBodies(minimumCredits: 5_000_000);
var allBodies = tracker.GetAllBodiesWorth();
```

### Calculators (For Manual Analysis)

```csharp
// Build context from scan
var context = PlanetContextBuilder.FromScan(scanEvent);

// Calculate worth
var worth = PlanetWorthCalculator.CalculateWorth(context);

// Or individual components
var exploration = ExplorationWorthCalculator.CalculateTotalExplorationValue(context);
var exobiology = ExobiologyWorthCalculator.CalculateExobiologyValue(context);
```

## Project Structure

```
EliteAPI/Exobiology/
├── Models/
│   ├── Species.cs              - 122 species with base values
│   ├── PlanetClass.cs          - Planet types with exploration values
│   ├── StarClass.cs            - Star types with exploration values
│   ├── AtmosphereType.cs       - Atmosphere types
│   ├── VolcanismType.cs        - Volcanism types
│   ├── SpawnCondition.cs       - Species spawn condition logic
│   └── PlanetContext.cs        - Planet data container
├── Calculators/
│   ├── ExplorationWorthCalculator.cs  - FSS/DSS/Footfall values
│   ├── ExobiologyWorthCalculator.cs   - Species predictions
│   └── PlanetWorthCalculator.cs       - Combined analysis
├── Data/
│   └── SpeciesSpawnConditions.cs      - Spawn rules for 122 species
├── Helpers/
│   └── PlanetContextBuilder.cs        - ScanEvent → PlanetContext
├── SystemTracker.cs                   - Multi-event state management
├── README.md                           - This file
└── USAGE.md                            - Detailed usage examples
```

## TODO

- [ ] Port remaining 112 species spawn conditions from Rust (10/122 done)
- [ ] Add galactic region calculations for region-specific species
- [ ] Add nebula proximity detection
- [ ] Add material presence checks for spawn conditions
- [ ] Improve first footfall detection accuracy

## Credits

- Exploration formulas from [ed-journals](https://github.com/jixxed/ed-journals) Rust project
- Species spawn conditions from [ed-journals](https://github.com/jixxed/ed-journals) Rust project
- Species base values from Elite Dangerous game data (Odyssey Update 18)
- Built for [EliteAPI](https://github.com/EliteAPI/EliteAPI) by Somfic
