namespace EliteAPI.Status.Models
{
    [Flags]
    public enum ShipStatusFlags
    {
        None = 0,
        Docked = 1,
        Landed = 1 << 1,
        Gear = 1 << 2,
        Shields = 1 << 3,
        Supercruise = 1 << 4,
        FlightAssistOff = 1 << 5,
        Hardpoints = 1 << 6,
        Winging = 1 << 7,
        Lights = 1 << 8,
        CargoScoop = 1 << 9,
        SilentRunning = 1 << 10,
        Scooping = 1 << 11,
        SrvHandbreak = 1 << 12,
        SrvTurret = 1 << 13,
        SrvNearShip = 1 << 14,
        SrvDriveAssist = 1 << 15,
        MassLocked = 1 << 16,
        FsdCharging = 1 << 17,
        FsdCooldown = 1 << 18,
        LowFuel = 1 << 19,
        Overheating = 1 << 20,
        HasLatlong = 1 << 21,
        InDanger = 1 << 22,
        InInterdiction = 1 << 23,
        InMothership = 1 << 24,
        InFighter = 1 << 25,
        InSrv = 1 << 26,
        AnalysisMode = 1 << 27,
        NightVision = 1 << 28
    }
}