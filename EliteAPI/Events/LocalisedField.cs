using System.Collections.Generic;

namespace EliteAPI.Events;

public readonly struct LocalisedField
{
    internal LocalisedField(string symbol)
    {
        Symbol = symbol;
    }

    /// <summary>The symbol value of the property.
    /// <remarks>In the format of <code>$symbolname;</code>.</remarks>
    /// </summary>
    public string Symbol { get; }

    /// <summary>The localised value of the property.</summary>
    /// <remarks>Values can differ based on the game's language.</remarks>
    public string Local => Localisation.GetLocalisedString(Symbol);

    public override string ToString()
    {
        return Local;
    }
}

public static class Localisation
{
    private static readonly Dictionary<string, string> LocalisedStrings = new();

    public static void SetLocalisedString(string? symbol, string? localised)
    {
        if (symbol == null || string.IsNullOrWhiteSpace(symbol))
            return;

        LocalisedStrings[symbol] = localised ?? string.Empty;
    }

    public static string GetLocalisedString(string? symbol)
    {
        if (symbol == null || string.IsNullOrWhiteSpace(symbol))
            return string.Empty;

        return LocalisedStrings.TryGetValue(symbol, out var value) ? value : symbol;
    }

    public static IReadOnlyDictionary<string, string> GetLocalisedStrings()
    {
        return LocalisedStrings;
    }
}
