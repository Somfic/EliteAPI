using EliteAPI;
using EliteAPI.Events;
using EliteAPI.Events.Game;
using EliteAPI.Exobiology;
using EliteAPI.Exobiology.Calculators;

Console.WriteLine("Elite Dangerous Exobiology Scanner");
Console.WriteLine("===================================\n");
Console.WriteLine("Watching journal for exobiology opportunities...\n");

var api = new EliteDangerousApi();
var tracker = new SystemTracker();
string currentSystem = "";

// Track body action states
var bodyStates = new Dictionary<string, BodyState>();

// Track session totals
long sessionTotalEarned = 0;

// Track star discovery state
bool mainStarWasDiscovered = false;

// Track system changes
api.On<FsdJumpEvent>((jump, context) =>
{
    currentSystem = jump.StarSystem;
    bodyStates.Clear();
    mainStarWasDiscovered = false;
    tracker.OnSystemChanged(currentSystem);

    if (!context.DuringCatchup)
    {
        RenderTable();
    }
});

// Track scans
api.On<ScanEvent>((scan, context) =>
{
    // Track all scanned bodies (including belt clusters, stars, etc.) for counting purposes
    if (!bodyStates.ContainsKey(scan.BodyName))
    {
        bodyStates[scan.BodyName] = new BodyState();
    }
    bodyStates[scan.BodyName].Discovered = true;

    // Track star scans for session total
    if (!string.IsNullOrEmpty(scan.StarType) && scan.DistanceFromArrivalLs == 0.0)
    {
        tracker.OnScan(scan);
        mainStarWasDiscovered = scan.WasDiscovered;

        if (!scan.WasDiscovered)
        {
            long starVal = tracker.GetMainStarValue();
            if (starVal > 0)
            {
                sessionTotalEarned += starVal;
            }
        }

        if (!context.DuringCatchup)
        {
            RenderTable();
        }
        return;
    }

    // Only process planets for exobiology tracking
    if (string.IsNullOrEmpty(scan.PlanetClass)) return;

    var body = tracker.OnScan(scan);

    bodyStates[scan.BodyName].WasAlreadyDiscovered = scan.WasDiscovered;
    bodyStates[scan.BodyName].WasAlreadyMapped = scan.WasMapped;

    // Track earnings from scanning (FSS discovery)
    if (!bodyStates[scan.BodyName].Mapped)
    {
        var worth = tracker.GetAllBodiesWorth().FirstOrDefault(b => b.BodyName == scan.BodyName);
        if (worth != null && !scan.WasDiscovered)
        {
            sessionTotalEarned += worth.ExplorationValueNotMapped;
        }
    }

    if (!context.DuringCatchup)
    {
        RenderTable();
    }
});

// Track FSS signals
api.On<FssBodySignalsEvent>((signals, context) =>
{
    tracker.OnFSSBodySignals(signals);

    if (!context.DuringCatchup)
    {
        RenderTable();
    }
});

// Track SAA signals (DSS mapping)
api.On<SaaSignalsFoundEvent>((signals, context) =>
{
    tracker.OnSAASignalsFound(signals);

    if (bodyStates.ContainsKey(signals.BodyName))
    {
        bodyStates[signals.BodyName].Mapped = true;
    }

    if (!context.DuringCatchup)
    {
        RenderTable();
    }
});

// Track SAA scan complete (mapping)
api.On<SaaScanCompleteEvent>((scan, context) =>
{
    if (bodyStates.ContainsKey(scan.BodyName))
    {
        bodyStates[scan.BodyName].Mapped = true;

        // Track earnings from mapping (DSS)
        var worth = tracker.GetAllBodiesWorth().FirstOrDefault(b => b.BodyName == scan.BodyName);
        if (worth != null)
        {
            // If we already counted FSS earnings, subtract them and add DSS earnings
            if (!bodyStates[scan.BodyName].WasAlreadyDiscovered)
            {
                sessionTotalEarned -= worth.ExplorationValueNotMapped;
                sessionTotalEarned += worth.ExplorationValueMapped;
            }
            // If already discovered, just add the mapping value difference
            else if (!bodyStates[scan.BodyName].WasAlreadyMapped)
            {
                sessionTotalEarned += worth.ExplorationValueMapped;
            }
        }
    }

    if (!context.DuringCatchup)
    {
        RenderTable();
    }
});

// Track organic scans (exobiology)
api.On<ScanOrganicEvent>((scan, context) =>
{
    // Find the body this scan is for by matching BodyID
    string? bodyName = null;

    // Try to find by BodyID
    foreach (var kvp in bodyStates)
    {
        if (!kvp.Value.Discovered) continue;

        var trackedBody = tracker.GetBody(kvp.Key);
        if (trackedBody?.Context?.BodyID == scan.Body.ToString())
        {
            bodyName = kvp.Key;
            break;
        }
    }

    if (bodyName != null && bodyStates.ContainsKey(bodyName))
    {
        var state = bodyStates[bodyName];
        var speciesName = scan.Species.Local;

        // Update scan count based on scan type
        int scanCount = scan.ScanType switch
        {
            "Log" => 1,
            "Sample" => 2,
            "Analyse" => 3,
            _ => 0
        };

        if (scanCount > 0)
        {
            state.ScannedSpecies[speciesName] = scanCount;

            // Track earnings when species is fully analyzed
            if (scanCount == 3)
            {
                // Try to match species name to our enum
                var worth = tracker.GetBodyWorth(bodyName);
                if (worth != null)
                {
                    // Find the matching species in predictions
                    var matchedSpecies = worth.ExobiologyValue.PossibleSpecies
                        .FirstOrDefault(p => p.Species.ToString().Contains(speciesName.Replace(" ", "")));

                    if (matchedSpecies != null)
                    {
                        state.BioEarnings += matchedSpecies.EstimatedValue;
                        sessionTotalEarned += matchedSpecies.EstimatedValue;
                    }
                }
            }
        }

        if (!context.DuringCatchup)
        {
            RenderTable();
        }
    }
});

// Track FSS scan complete
api.On<FssDiscoveryScanEvent>((fss, context) =>
{
    // Remove old unknown body placeholders
    var unknownKeys = bodyStates.Keys.Where(k => k.StartsWith("Unknown Body")).ToList();
    foreach (var key in unknownKeys)
    {
        bodyStates.Remove(key);
    }

    // Count how many bodies we've actually discovered
    int discoveredBodies = bodyStates.Count(kvp => kvp.Value.Discovered);
    int totalBodies = (int)fss.BodyCount;

    // Add placeholders for bodies we know exist but haven't scanned yet
    for (int i = discoveredBodies; i < totalBodies; i++)
    {
        bodyStates[$"Unknown Body {i + 1}"] = new BodyState { Discovered = false };
    }

    if (!context.DuringCatchup)
    {
        RenderTable();
    }
});

api.Start();

// Render initial table after catchup is complete
if (!string.IsNullOrEmpty(currentSystem))
{
    RenderTable();
}

void RenderTable()
{
    var allBodies = tracker.GetAllBodiesWorth();

    // Clear entire console
    Console.Clear();

    // System header
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
    Console.WriteLine($"║ System: {currentSystem,-113} ║");
    Console.WriteLine($"╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝\n");
    Console.ResetColor();

    // Table header
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("┌────────────────────────────────────┬─────────────────┬─────────────────┬─────────────────┬─────────────────────────────────────┐");
    Console.WriteLine("│ Body Name                          │ Not Mapped      │ Mapped          │ Exobiology      │ Species                             │");
    Console.WriteLine("├────────────────────────────────────┼─────────────────┼─────────────────┼─────────────────┼─────────────────────────────────────┤");
    Console.ResetColor();

    long totalNotMapped = 0;
    long totalMapped = 0;
    long totalExobiology = 0; // Only landable planets

    // Star row
    long starValue = tracker.GetMainStarValue();
    if (starValue > 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"│ {"(Star)",-34} │ ");

        if (mainStarWasDiscovered)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            totalNotMapped += starValue;
        }
        Console.Write($"{starValue,15:N0}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" │ ");

        if (mainStarWasDiscovered)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            totalMapped += starValue;
        }
        Console.Write($"{starValue,15:N0}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" │ ");

        Console.Write($"{"",15}");
        Console.Write(" │ ");
        Console.Write($"{"",37}");
        Console.WriteLine(" │");
        Console.ResetColor();
    }

    // Only show bodies that are either:
    // 1. Have worth data (planets tracked by exobiology system)
    // 2. Unknown placeholders
    var displayBodyNames = bodyStates.Keys
        .Where(name => name.StartsWith("Unknown Body") || allBodies.Any(b => b.BodyName == name))
        .ToList();

    // Sort bodies: discovered first (by value), then undiscovered
    var sortedBodyNames = displayBodyNames
        .OrderByDescending(name => bodyStates[name].Discovered)
        .ThenByDescending(name =>
        {
            var worth = allBodies.FirstOrDefault(b => b.BodyName == name);
            return worth?.MaximumTotalValue ?? 0;
        })
        .ToList();

    foreach (var bodyName in sortedBodyNames)
    {
        var state = bodyStates[bodyName];

        if (!state.Discovered)
            continue;


        var worth = allBodies.FirstOrDefault(b => b.BodyName == bodyName);
        if (worth == null) continue;

        // Body name (with debug info) - strip system name prefix
        var debugInfo = worth.BiologicalSignals > 0 ? $" [{worth.BiologicalSignals}]" : "";

        var displayName = bodyName.StartsWith(currentSystem + " ")
            ? bodyName.Substring(currentSystem.Length + 1)
            : bodyName;

        // Add strikethrough if already discovered
        if (state.WasAlreadyDiscovered)
        {
            displayName = string.Concat(displayName.Select(c => c + "\u0336"));
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.Write($"│ {(displayName + debugInfo),-34} │ ");

        // Not Mapped Value (exploration only - FSS + first footfall, NO bio)
        long notMappedValue = worth.ExplorationValueNotMapped;
        if (state.WasAlreadyDiscovered || state.Mapped)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            totalNotMapped += notMappedValue;
        }
        Console.Write($"{notMappedValue,15:N0}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" │ ");

        // Mapped Value (exploration only - FSS + DSS + first footfall, NO bio)
        long mappedValue = worth.ExplorationValueMapped;
        // Only highlight based on exploration value (not exobiology)
        bool isHighValue = !state.Mapped && mappedValue >= 1_000_000;

        if (state.Mapped)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            totalMapped += mappedValue;
        }
        else if (isHighValue)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
        Console.Write($"{mappedValue,15:N0}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" │ ");

        // Show actual bio earnings if we've scanned species, otherwise show predictions
        if (state.BioEarnings > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{state.BioEarnings,15:N0}");
            totalExobiology += state.BioEarnings;
        }
        else if (worth.ExobiologyValue.MinimumValue > 0)
        {
            long exobiologyValue = worth.ExobiologyValue.MinimumValue;
            if (isHighValue)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            Console.Write($"{exobiologyValue,15:N0}");
        }
        else if (worth.BiologicalSignals > 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{worth.BiologicalSignals + " sig",15}");
        }
        else
        {
            Console.Write($"{"",15}");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" │ ");

        // Species column - show scanned species with progress
        if (state.ScannedSpecies.Count > 0)
        {
            var speciesDisplay = string.Join(", ", state.ScannedSpecies
                .Select(kvp => $"{kvp.Key.Replace("Stratum ", "").Replace("Tussock ", "").Replace("Fungoida ", "")} ({kvp.Value}/3)")
                .Take(2));
            if (state.ScannedSpecies.Count > 2)
                speciesDisplay += $" +{state.ScannedSpecies.Count - 2}";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{speciesDisplay,-37}");
        }
        else if (worth.ExobiologyValue.PossibleSpecies.Count > 0)
        {
            var speciesNames = worth.ExobiologyValue.PossibleSpecies
                .Select(s => s.Species.ToString())
                .Take(3);
            var speciesDisplay = string.Join(", ", speciesNames);
            if (worth.ExobiologyValue.PossibleSpecies.Count > 3)
                speciesDisplay += $" +{worth.ExobiologyValue.PossibleSpecies.Count - 3}";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{speciesDisplay,-37}");
        }
        else
        {
            Console.Write($"{"",37}");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" │");

        Console.WriteLine();
        Console.ResetColor();
    }

    // Totals row
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("├────────────────────────────────────┼─────────────────┼─────────────────┼─────────────────┼─────────────────────────────────────┤");
    Console.Write("│ ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"{"TOTAL",-34}");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" │ ");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{totalNotMapped,15:N0}");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" │ ");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{totalMapped,15:N0}");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" │ ");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{totalExobiology,15:N0}");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" │ ");

    Console.Write($"{"",37}");
    Console.WriteLine(" │");

    Console.WriteLine("└────────────────────────────────────┴─────────────────┴─────────────────┴─────────────────┴─────────────────────────────────────┘");
    Console.ResetColor();

    // Calculate system totals
    long systemActual = mainStarWasDiscovered ? 0 : starValue; // Include star value only if not already discovered
    long systemPotential = starValue; // Include star value

    foreach (var body in allBodies.Where(b => bodyStates.ContainsKey(b.BodyName) && bodyStates[b.BodyName].Discovered))
    {
        var state = bodyStates[body.BodyName];

        // Actual: what we've already earned in this system
        if (state.Mapped)
        {
            systemActual += body.ExplorationValueMapped;
        }
        else if (!state.WasAlreadyDiscovered)
        {
            systemActual += body.ExplorationValueNotMapped;
        }

        // Add bio earnings from scanned species
        systemActual += state.BioEarnings;

        // Potential: maximum possible if we do everything
        long bioValue = body.IsLandable ? body.ExobiologyValue.MaximumValue : 0;
        systemPotential += body.ExplorationValueMapped + bioValue;
    }

    // Display system and session totals
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("System Actual: ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{systemActual:N0} cr");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write(" / ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Potential: ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{systemPotential:N0} cr");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Session Earned (if sold now): ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{sessionTotalEarned:N0} cr");
    Console.ResetColor();
}

await Task.Delay(-1);

class BodyState
{
    public bool Discovered { get; set; } = false;
    public bool Mapped { get; set; } = false;
    public bool BioScanned { get; set; } = false;
    public bool WasAlreadyDiscovered { get; set; } = false;
    public bool WasAlreadyMapped { get; set; } = false;
    public Dictionary<string, int> ScannedSpecies { get; set; } = new(); // Species name -> scan count (1=Log, 2=Sample, 3=Analyse)
    public long BioEarnings { get; set; } = 0;
}
