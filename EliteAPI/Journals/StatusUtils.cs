using System.Collections.Generic;

namespace EliteAPI.Journals
{
    public static class StatusUtils
    {
        public static Dictionary<string, bool> GetFlags(int flags) => new()
        {
            { "Available", flags != 0 },
            { "Docked", (flags & 1) != 0 },
            { "Landed", (flags & (1 << 1)) != 0 },
            { "Gear", (flags & (1 << 2)) != 0 },
            { "Shields", (flags & (1 << 3)) != 0 },
            { "Supercruise", (flags & (1 << 4)) != 0 },
            { "FlightAssistOff", (flags & (1 << 5)) != 0 },
            { "Hardpoints", (flags & (1 << 6)) != 0 },
            { "Winging", (flags & (1 << 7)) != 0 },
            { "Lights", (flags & (1 << 8)) != 0 },
            { "CargoScoop", (flags & (1 << 9)) != 0 },
            { "SilentRunning", (flags & (1 << 10)) != 0 },
            { "Scooping", (flags & (1 << 11)) != 0 },
            { "SrvHandbreak", (flags & (1 << 12)) != 0 },
            { "SrvTurret", (flags & (1 << 13)) != 0 },
            { "SrvNearShip", (flags & (1 << 14)) != 0 },
            { "SrvDriveAssist", (flags & (1 << 15)) != 0 },
            { "MassLocked", (flags & (1 << 16)) != 0 },
            { "FsdCharging", (flags & (1 << 17)) != 0 },
            { "FsdCooldown", (flags & (1 << 18)) != 0 },
            { "LowFuel", (flags & (1 << 19)) != 0 },
            { "Overheating", (flags & (1 << 20)) != 0 },
            { "HasLatlong", (flags & (1 << 21)) != 0 },
            { "InDanger", (flags & (1 << 22)) != 0 },
            { "InInterdiction", (flags & (1 << 23)) != 0 },
            { "InMothership", (flags & (1 << 24)) != 0 },
            { "InFighter", (flags & (1 << 25)) != 0 },
            { "InSrv", (flags & (1 << 26)) != 0 },
            { "AnalysisMode", (flags & (1 << 27)) != 0 },
            { "NightVision", (flags & (1 << 28)) != 0 }
        };

        public static Dictionary<string, bool> GetFlags2(int flags2) => new()
        {
            { "OnFoot", (flags2 & 1) != 0 },
            { "InTaxi", (flags2 & (1 << 1)) != 0 },
            { "InMultiCrew", (flags2 & (1 << 2)) != 0 },
            { "OnFootInStation", (flags2 & (1 << 3)) != 0 },
            { "OnFootOnPlanet", (flags2 & (1 << 4)) != 0 },
            { "AimDownSight", (flags2 & (1 << 5)) != 0 },
            { "LowOxygen", (flags2 & (1 << 6)) != 0 },
            { "LowHealth", (flags2 & (1 << 7)) != 0 },
            { "Cold", (flags2 & (1 << 8)) != 0 },
            { "Hot", (flags2 & (1 << 9)) != 0 },
            { "VeryCold", (flags2 & (1 << 10)) != 0 },
            { "VeryHot", (flags2 & (1 << 11)) != 0 },
            { "Gliding", (flags2 & (1 << 12)) != 0 },
            { "OnFootInHangar", (flags2 & (1 << 13)) != 0 },
            { "OnFootInSocialSpace", (flags2 & (1 << 14)) != 0 },
            { "OnFootInExterior", (flags2 & (1 << 15)) != 0 },
            { "BreathableAtmosphere", (flags2 & (1 << 16)) != 0 }
        };

        public static Dictionary<string, long> GetPips(int[] pips) => new()
        {
            { "Pips.System", pips.Length > 0 ? pips[0] : 0 },
            { "Pips.Engine", pips.Length > 1 ? pips[1] : 0 },
            { "Pips.Weapons", pips.Length > 2 ? pips[2] : 0 }
        };
    }
}
