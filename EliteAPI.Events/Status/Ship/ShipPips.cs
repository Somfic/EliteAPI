namespace EliteAPI.Events.Status.Ship;

public readonly struct ShipPips
{
    internal ShipPips(int system, int engines, int weapons)
    {
        System = system;
        Engines = engines;
        Weapons = weapons;
    }

    /// <summary>
    /// Amount of half pips set to systems
    /// </summary>
    public int System { get; }

    /// <summary>
    /// Amount of half pips set to engines
    /// </summary>
    public int Engines { get; }

    /// <summary>
    /// Amount of half pips set to weapons
    /// </summary>
    public int Weapons { get; }
}