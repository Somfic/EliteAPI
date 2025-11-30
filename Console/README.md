# Elite Dangerous Exobiology Scanner Console

A real-time console application that tracks your current Elite Dangerous system and shows you how much it's worth in exploration and exobiology credits.

## Features

- **Live System Tracking** - Automatically tracks which system you're in
- **Real-time Worth Calculation** - Updates as you scan bodies and find biological signals
- **System Summary** - Shows total system value broken down by:
  - Total Exploration Value (FSS + DSS + First Footfall)
  - Total Exobiology Value (all predicted species)
  - Grand Total System Value
- **Worthwhile Bodies List** - Highlights planets worth > 1M credits with color coding:
  - 🟣 Magenta: > 50M cr
  - 🟡 Yellow: > 20M cr
  - 🟢 Green: > 5M cr
  - ⚪ Gray: > 1M cr
- **Species Predictions** - Shows which bio species are likely on each body

## Usage

### Run the Application

```bash
cd Console
dotnet run
```

The application will:
1. Connect to Elite Dangerous journal files
2. Wait for you to jump into a system
3. Track all scans and FSS/DSS events
4. Display running totals after each scan

### What You'll See

#### On System Jump
```
╔═══════════════════════════════════════════════════════╗
║ Jumped to: Praea Euq AA-A h0                         ║
╚═══════════════════════════════════════════════════════╝
```

#### On Scan
```
[Scan] Praea Euq AA-A h0 3 a
  ⚠ Potential bio signals detected
  Possible species: 3
```

#### On FSS (Full Spectrum Scan)
```
[FSS] Praea Euq AA-A h0 3 a
  Bio Signals: 3
  Predicted species: 3
  Estimated bio value: 21,667,840 cr
  Total value: 21,705,343 cr
    • BacteriumAurasus: 1,600,000 cr
    • BacteriumNebulus: 8,463,840 cr
    • AleoidaArcus: 11,604,000 cr
```

#### System Summary (Auto-updates)
```
╔═══════════════════════════════════════════════════════╗
║ System: Praea Euq AA-A h0                            ║
╠═══════════════════════════════════════════════════════╣
║ Bodies scanned: 12                                    ║
║ Bodies with bio signals: 4                            ║
╠═══════════════════════════════════════════════════════╣
║ Total Exploration Value:              2,847,392 cr    ║
║ Total Exobiology Value:              87,456,230 cr    ║
║ ───────────────────────────────────────────────────── ║
║ TOTAL SYSTEM VALUE:                  90,303,622 cr    ║
╚═══════════════════════════════════════════════════════╝

┌─── Worthwhile Bodies (> 1M cr) ───┐
  Praea Euq AA-A h0 3 a                      21,705,343 cr
    └─ 3 bio signals, 3 possible species
  Praea Euq AA-A h0 4 b                      34,892,100 cr
    └─ 2 bio signals, 2 possible species
  Praea Euq AA-A h0 5                        18,234,567 cr
    └─ 1 bio signals, 1 possible species
```

## How It Works

1. **Tracks FSD Jumps** - Clears data when you jump to a new system
2. **Processes Scans** - Captures planet properties (temp, gravity, atmosphere, etc.)
3. **Adds FSS Data** - Updates with biological signal counts from Full Spectrum Scanner
4. **Adds DSS Data** - Updates with specific genera from Detailed Surface Scanner
5. **Calculates Worth** - Runs predictions based on spawn conditions for 122 species

The system value is the sum of:
- **FSS Value**: Basic discovery scan
- **DSS Value**: Detailed surface mapping (8-9.6x multiplier)
- **First Footfall**: ~50% bonus if you land first
- **Exobiology**: All predicted species fully scanned (3 samples each)

## Tips

- **Wait for FSS** - Initial scan predictions improve dramatically after FSS
- **Check worthwhile list** - Bodies highlighted in yellow/magenta are extremely valuable
- **First discoveries** - Undiscovered systems are worth 9.6x more for mapping
- **Species count matters** - More predicted species = more potential value

## Notes

- Currently using 10 example species for predictions
- Remaining 112 species need to be ported from Rust source
- Predictions will be more accurate once all spawn conditions are implemented
- First footfall detection is estimated (assumes undiscovered = untouched)

## Exit

Press `Ctrl+C` to stop the application.
