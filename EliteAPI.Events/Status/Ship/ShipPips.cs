namespace EliteAPI.Events.Status.Ship;

public readonly struct ShipPips
{
    internal ShipPips(long system, long engines, long weapons)
    {
        System = system;
        Engines = engines;
        Weapons = weapons;
    }

    /// <summary>
    /// Amount of half pips set to systems
    /// </summary>
    public long System { get; }

    /// <summary>
    /// Amount of half pips set to engines
    /// </summary>
    public long Engines { get; }

    /// <summary>
    /// Amount of half pips set to weapons
    /// </summary>
    public long Weapons { get; }
}