namespace EliteAPI.Events;

public readonly struct Localised
{
    public Localised(string symbol, string localised)
    {
        Symbol = symbol;
        Local = localised;
    }

    /// <summary>The symbol value of the property.
    /// <remarks>In the format of <code>$symbolname;</code>.</remarks>
    /// </summary>
    public string Symbol { get; }

    /// <summary>The localised value of the property.</summary>
    /// <remarks>Values can differ based on the game's language.</remarks>
    public string Local { get; }

    public override string ToString()
    {
        return Local;
    }
}