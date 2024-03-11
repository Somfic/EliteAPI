namespace EliteAPI.Status.Ship;

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
    VeryHot = 1 << 11,
    Gliding = 1 << 12,
    OnFootInHangar = 1 << 13,
    OnFootSocialSpace = 1 << 14,
    OnFootExterior = 1 << 15,
    BreathableAtmosphere = 1 << 16,
}