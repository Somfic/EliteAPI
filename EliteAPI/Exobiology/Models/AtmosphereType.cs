namespace EliteAPI.Exobiology.Models;

/// <summary>
/// Atmosphere types for planetary bodies in Elite Dangerous.
/// </summary>
public enum AtmosphereType
{
    None,
    CarbonDioxide,
    Ammonia,
    Water,
    Oxygen,
    Argon,
    Nitrogen,
    Helium,
    Neon,
    Methane,
    Silicate,
    Metallic,
    SulphurDioxide,

    // Rich variants
    NitrogenRich,
    ArgonRich,
    NeonRich,
    HeliumRich,
    MetallicRich,
    WaterRich,
    AmmoniaRich,
    CarbonDioxideRich,
    MethaneRich,
    OxygenRich,
}

public static class AtmosphereTypeExtensions
{
    /// <summary>
    /// Parses an atmosphere type from journal string.
    /// </summary>
    public static AtmosphereType? ParseFromJournal(string? journalValue)
    {
        if (string.IsNullOrEmpty(journalValue))
            return AtmosphereType.None;

        var normalized = journalValue.ToLowerInvariant().Replace(" ", "").Replace("-", "");

        return normalized switch
        {
            "" or "none" => AtmosphereType.None,
            "carbondioxide" or "co2" => AtmosphereType.CarbonDioxide,
            "ammonia" => AtmosphereType.Ammonia,
            "water" or "h2o" => AtmosphereType.Water,
            "oxygen" or "o2" => AtmosphereType.Oxygen,
            "argon" => AtmosphereType.Argon,
            "nitrogen" or "n2" => AtmosphereType.Nitrogen,
            "helium" or "he" => AtmosphereType.Helium,
            "neon" or "ne" => AtmosphereType.Neon,
            "methane" or "ch4" => AtmosphereType.Methane,
            "silicatevapour" or "silicate" => AtmosphereType.Silicate,
            "metallicvapour" or "metallic" => AtmosphereType.Metallic,
            "sulphurdioxide" or "so2" => AtmosphereType.SulphurDioxide,

            // Rich variants
            "nitrogenrich" => AtmosphereType.NitrogenRich,
            "argonrich" => AtmosphereType.ArgonRich,
            "neonrich" => AtmosphereType.NeonRich,
            "heliumrich" => AtmosphereType.HeliumRich,
            "metallicrich" => AtmosphereType.MetallicRich,
            "waterrich" => AtmosphereType.WaterRich,
            "ammoniarich" => AtmosphereType.AmmoniaRich,
            "carbondioxiderich" => AtmosphereType.CarbonDioxideRich,
            "methanerich" => AtmosphereType.MethaneRich,
            "oxygenrich" => AtmosphereType.OxygenRich,

            _ => null
        };
    }

    /// <summary>
    /// Checks if this is a "thin" atmosphere variant.
    /// Thin atmospheres are indicated by values like "thin carbon dioxide" in the journal.
    /// </summary>
    public static bool IsThinAtmosphere(string? journalValue)
    {
        return journalValue?.ToLowerInvariant().Contains("thin") ?? false;
    }
}
