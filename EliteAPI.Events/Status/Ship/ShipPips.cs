namespace EliteAPI.Events.Status.Ship;

public readonly struct ShipPips
{
    private readonly IList<int> _pips;

    internal ShipPips(IList<int> pips)
    {
        _pips = pips;
    }

    /// <summary>
    /// Amount of half pips set to systems
    /// </summary>
    public int System => _pips[0];

    /// <summary>
    /// Amount of half pips set to engines
    /// </summary>
    public int Engines => _pips[1];

    /// <summary>
    /// Amount of half pips set to weapons
    /// </summary>
    public int Weapons => _pips[2];
}