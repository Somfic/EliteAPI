namespace EliteAPI.Exobiology.Models;

/// <summary>
/// Star classification types in Elite Dangerous.
/// </summary>
public enum StarClass
{
    // Main sequence
    O,  // Blue
    B,  // Blue-white
    A,  // White
    F,  // Yellow-white
    G,  // Yellow
    K,  // Orange
    M,  // Red
    L,  // Brown dwarf
    T,  // Brown dwarf
    Y,  // Brown dwarf

    // Proto-stars
    AeBe,
    TTS,

    // Wolf-Rayet
    W,
    WN,
    WNC,
    WC,
    WO,

    // Carbon stars
    C,
    CN,
    CJ,
    CS,
    MS,
    S,

    // White dwarfs
    D,
    DA,
    DAB,
    DAO,
    DAZ,
    DAV,
    DB,
    DBZ,
    DBV,
    DO,
    DOV,
    DQ,
    DC,
    DCV,
    DX,

    // Neutron stars
    N,

    // Black holes
    H,
    SupermassiveBlackHole,

    // Exotic
    X,
}

/// <summary>
/// Star luminosity classes (Morgan-Keenan classification).
/// </summary>
public enum StarLuminosity
{
    /// <summary>Hypergiants or extremely luminous supergiants</summary>
    O,

    /// <summary>Luminous supergiants</summary>
    Ia,

    /// <summary>Intermediate luminous supergiants</summary>
    Iab,

    /// <summary>Less luminous supergiants</summary>
    Ib,

    /// <summary>Bright giants</summary>
    II,

    /// <summary>Normal giants</summary>
    III,

    /// <summary>Subgiants</summary>
    IV,

    /// <summary>Main sequence (dwarfs)</summary>
    V,

    /// <summary>Subdwarfs</summary>
    VI,

    /// <summary>White dwarfs</summary>
    VII,
}

public static class StarClassExtensions
{
    /// <summary>
    /// Gets the base exploration value for this star class.
    /// </summary>
    public static float GetBaseValue(this StarClass starClass)
    {
        return starClass switch
        {
            // White dwarfs
            StarClass.D or StarClass.DA or StarClass.DAB or StarClass.DAO or
            StarClass.DAZ or StarClass.DAV or StarClass.DB or StarClass.DBZ or
            StarClass.DBV or StarClass.DO or StarClass.DOV or StarClass.DQ or
            StarClass.DC or StarClass.DCV or StarClass.DX => 14_057f,

            // Neutron stars and black holes
            StarClass.N or StarClass.H => 22_628f,

            // Supermassive black hole
            StarClass.SupermassiveBlackHole => 33.5678f,

            // All other stars
            _ => 1_200f
        };
    }

    /// <summary>
    /// Parses a star class from journal string.
    /// </summary>
    public static StarClass? ParseFromJournal(string? journalValue)
    {
        if (string.IsNullOrEmpty(journalValue))
            return null;

        var normalized = journalValue.ToUpperInvariant().Replace(" ", "").Replace("_", "").Replace("-", "");

        return normalized switch
        {
            "O" => StarClass.O,
            "B" or "BLUEWHITESUPERGIANT" or "BBLUEWHITESUPERGIANT" => StarClass.B,
            "A" or "ABLUEWHITESUPERGIANT" => StarClass.A,
            "F" or "WHITESUPERGIANT" or "FWHITESUPERGIANT" => StarClass.F,
            "G" or "GWHITESUPERGIANT" => StarClass.G,
            "K" or "ORANGEGIANT" or "KORANGEGIANT" => StarClass.K,
            "M" or "REDGIANT" or "REDSUPERGIANT" or "MREDGIANT" or "MREDSUPERGIANT" => StarClass.M,
            "L" => StarClass.L,
            "T" => StarClass.T,
            "Y" => StarClass.Y,

            "AEBE" or "HERBIGAEBESTAR" => StarClass.AeBe,
            "TTS" or "TTAURISTAR" => StarClass.TTS,

            "W" => StarClass.W,
            "WN" => StarClass.WN,
            "WNC" => StarClass.WNC,
            "WC" => StarClass.WC,
            "WO" => StarClass.WO,

            "C" or "CSTAR" => StarClass.C,
            "CN" => StarClass.CN,
            "CJ" => StarClass.CJ,
            "CS" => StarClass.CS,
            "MS" or "MSSTAR" => StarClass.MS,
            "S" or "SSTAR" => StarClass.S,

            "D" => StarClass.D,
            "DA" => StarClass.DA,
            "DAB" => StarClass.DAB,
            "DAO" => StarClass.DAO,
            "DAZ" => StarClass.DAZ,
            "DAV" => StarClass.DAV,
            "DB" => StarClass.DB,
            "DBZ" => StarClass.DBZ,
            "DBV" => StarClass.DBV,
            "DO" => StarClass.DO,
            "DOV" => StarClass.DOV,
            "DQ" => StarClass.DQ,
            "DC" => StarClass.DC,
            "DCV" => StarClass.DCV,
            "DX" => StarClass.DX,

            "N" or "NEUTRONSTAR" => StarClass.N,
            "H" or "BLACKHOLE" => StarClass.H,
            "SUPERMASSIVEBLACKHOLE" => StarClass.SupermassiveBlackHole,

            "X" => StarClass.X,

            _ => null
        };
    }

    /// <summary>
    /// Gets the base star class without giant/supergiant modifier.
    /// </summary>
    public static StarClass GetBaseClass(this StarClass starClass)
    {
        // Already base classes
        return starClass;
    }
}

public static class StarLuminosityExtensions
{
    /// <summary>
    /// Parses star luminosity from journal string.
    /// </summary>
    public static StarLuminosity? ParseFromJournal(string? luminosityString)
    {
        if (string.IsNullOrEmpty(luminosityString))
            return StarLuminosity.V; // Default to main sequence

        var normalized = luminosityString.ToUpperInvariant().Trim();

        return normalized switch
        {
            "0" or "O" => StarLuminosity.O,
            "IA" => StarLuminosity.Ia,
            "IAB" => StarLuminosity.Iab,
            "IB" => StarLuminosity.Ib,
            "II" => StarLuminosity.II,
            "III" => StarLuminosity.III,
            "IV" => StarLuminosity.IV,
            "V" => StarLuminosity.V,
            "VI" => StarLuminosity.VI,
            "VII" => StarLuminosity.VII,
            _ => StarLuminosity.V // Default to main sequence
        };
    }
}
