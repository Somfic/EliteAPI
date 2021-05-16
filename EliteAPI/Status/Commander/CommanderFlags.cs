using System;

namespace EliteAPI.Status.Ship
{
    [Flags]
    public enum CommanderFlags
    {
        None = 0,
        OnFoot = 1,
        InTaxi = 1 << 1,
        InMultiCrew = 1 << 2,
        OnFootInStation = 1 << 3,
        OnFootOnPlanet = 1 << 4,
        AimDownSight = 1 << 5,
        LowOxygen = 1 << 6,
        LowHealth = 1 << 7,
        Cold = 1 << 8,
        Hot = 1 << 9,
        VeryCold = 1 << 10,
        VeryHot = 1 << 11
    }
}