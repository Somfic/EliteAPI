namespace EliteAPI.Exobiology.Models;

/// <summary>
/// Volcanism types for planetary bodies in Elite Dangerous.
/// </summary>
public enum VolcanismType
{
    None,

    // Geysers
    CarbonDioxideGeysers,
    WaterGeysers,
    AmmoniaGeysers,
    MethaneGeysers,
    NitrogenGeysers,
    HeliumGeysers,
    SilicateVapourGeysers,

    // Magma
    RockyMagma,
    SilicateMagma,
    MetallicMagma,
    WaterMagma,
    IceMagma,
    MethaneMagma,
    NitrogenMagma,
}

public static class VolcanismTypeExtensions
{
    /// <summary>
    /// Parses a volcanism type from journal string.
    /// </summary>
    public static VolcanismType? ParseFromJournal(string? journalValue)
    {
        if (string.IsNullOrEmpty(journalValue))
            return VolcanismType.None;

        var normalized = journalValue.ToLowerInvariant().Replace(" ", "").Replace("-", "");

        // Remove intensity prefixes like "major", "minor", etc.
        normalized = normalized
            .Replace("major", "")
            .Replace("minor", "")
            .Replace("strong", "")
            .Replace("weak", "");

        return normalized switch
        {
            "" or "none" or "novolcanism" => VolcanismType.None,

            _ when normalized.Contains("carbondioxidegeyser") => VolcanismType.CarbonDioxideGeysers,
            _ when normalized.Contains("watergeyser") => VolcanismType.WaterGeysers,
            _ when normalized.Contains("ammoniageyser") => VolcanismType.AmmoniaGeysers,
            _ when normalized.Contains("methanegeyser") => VolcanismType.MethaneGeysers,
            _ when normalized.Contains("nitrogengeyser") => VolcanismType.NitrogenGeysers,
            _ when normalized.Contains("heliumgeyser") => VolcanismType.HeliumGeysers,
            _ when normalized.Contains("silicatevapour") => VolcanismType.SilicateVapourGeysers,

            _ when normalized.Contains("rockymagma") => VolcanismType.RockyMagma,
            _ when normalized.Contains("silicatemagma") => VolcanismType.SilicateMagma,
            _ when normalized.Contains("metallicmagma") => VolcanismType.MetallicMagma,
            _ when normalized.Contains("watermagma") => VolcanismType.WaterMagma,
            _ when normalized.Contains("icemagma") => VolcanismType.IceMagma,
            _ when normalized.Contains("methanemagma") => VolcanismType.MethaneMagma,
            _ when normalized.Contains("nitrogenmagma") => VolcanismType.NitrogenMagma,

            _ => null
        };
    }

    /// <summary>
    /// Checks if the body has any volcanism (not None).
    /// </summary>
    public static bool IsAnyVolcanism(VolcanismType? volcanism)
    {
        return volcanism.HasValue && volcanism.Value != VolcanismType.None;
    }
}
