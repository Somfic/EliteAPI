namespace EliteAPI.Exobiology.Models;

/// <summary>
/// Planet classification types in Elite Dangerous.
/// </summary>
public enum PlanetClass
{
    MetalRichBody,
    AmmoniaWorld,
    SudarskyClassIGasGiant,
    SudarskyClassIIGasGiant,
    SudarskyClassIIIGasGiant,
    SudarskyClassIVGasGiant,
    SudarskyClassVGasGiant,
    HighMetalContentBody,
    WaterWorld,
    EarthlikeBody,
    RockyBody,
    IcyBody,
    RockyIceBody,
    HeliumRichGasGiant,
    HeliumGasGiant,
    WaterGiant,
    GasGiantWithWaterBasedLife,
    GasGiantWithAmmoniaBasedLife,
}

/// <summary>
/// Extension methods for PlanetClass enum.
/// </summary>
public static class PlanetClassExtensions
{
    /// <summary>
    /// Gets the base exploration value for this planet class.
    /// </summary>
    public static long GetBaseValue(this PlanetClass planetClass)
    {
        return planetClass switch
        {
            PlanetClass.MetalRichBody => 21_790,
            PlanetClass.AmmoniaWorld => 96_932,
            PlanetClass.SudarskyClassIGasGiant => 1_656,
            PlanetClass.SudarskyClassIIGasGiant => 9_654,
            PlanetClass.HighMetalContentBody => 9_654,
            PlanetClass.WaterWorld => 64_831,
            PlanetClass.EarthlikeBody => 64_831,
            _ => 300
        };
    }

    /// <summary>
    /// Gets the bonus exploration value if the planet is terraformable.
    /// </summary>
    public static long GetTerraformableBonus(this PlanetClass planetClass)
    {
        return planetClass switch
        {
            PlanetClass.MetalRichBody => 65_631,
            PlanetClass.AmmoniaWorld => 0,
            PlanetClass.SudarskyClassIGasGiant => 0,
            PlanetClass.SudarskyClassIIGasGiant => 100_677,
            PlanetClass.HighMetalContentBody => 100_677,
            PlanetClass.WaterWorld => 116_295,
            PlanetClass.EarthlikeBody => 116_295,
            _ => 93_328
        };
    }

    /// <summary>
    /// Parses a planet class string from the game journal.
    /// </summary>
    public static PlanetClass? ParseFromJournal(string? journalValue)
    {
        if (string.IsNullOrEmpty(journalValue))
            return null;

        return journalValue.ToLowerInvariant().Replace(" ", "") switch
        {
            "metalrichbody" => PlanetClass.MetalRichBody,
            "ammoniaworld" => PlanetClass.AmmoniaWorld,
            "sudarskyclassigasgiant" => PlanetClass.SudarskyClassIGasGiant,
            "sudarskyclassiigasgiant" => PlanetClass.SudarskyClassIIGasGiant,
            "sudarskyclassiiigasgiant" => PlanetClass.SudarskyClassIIIGasGiant,
            "sudarskyclassivgasgiant" => PlanetClass.SudarskyClassIVGasGiant,
            "sudarskyclassvgasgiant" => PlanetClass.SudarskyClassVGasGiant,
            "highmetalcontentbody" => PlanetClass.HighMetalContentBody,
            "waterworld" => PlanetClass.WaterWorld,
            "earthlikebody" => PlanetClass.EarthlikeBody,
            "rockybody" => PlanetClass.RockyBody,
            "icybody" => PlanetClass.IcyBody,
            "rockyicebody" => PlanetClass.RockyIceBody,
            "heliumrichgasgiant" => PlanetClass.HeliumRichGasGiant,
            "heliumgasgiant" => PlanetClass.HeliumGasGiant,
            "watergiant" => PlanetClass.WaterGiant,
            "gasgiantwithwaterbasedlife" => PlanetClass.GasGiantWithWaterBasedLife,
            "gasgiantwithammoniabasedlife" => PlanetClass.GasGiantWithAmmoniaBasedLife,
            _ => null
        };
    }
}
