namespace EliteAPI.Exobiology.Models;

/// <summary>
/// Elite Dangerous exobiology species with base scan values.
/// </summary>
public enum Species
{
    // Aleoida
    AleoidaArcus,
    AleoidaCoronamus,
    AleoidaSpica,
    AleoidaLaminiae,
    AleoidaGravis,

    // Amphora Plant
    AmphoraPlant,

    // Anemone
    AnemoneLuteolum,
    AnemoneCroceum,
    AnemonePuniceum,
    AnemoneRoseum,
    AnemoneBlatteumBioluminescent,
    AnemoneRubeumBioluminescent,
    AnemonePrasinumBioluminescent,
    AnemoneRoseumBioluminescent,

    // Bark Mound
    BarkMound,

    // Bacterium
    BacteriumAurasus,
    BacteriumNebulus,
    BacteriumScopulum,
    BacteriumAcies,
    BacteriumVesicula,
    BacteriumAlcyoneum,
    BacteriumTela,
    BacteriumInformem,
    BacteriumVolu,
    BacteriumBullaris,
    BacteriumOmentum,
    BacteriumCerbrus,
    BacteriumVerrata,

    // Brain Tree
    BrainTreeRoseum,
    BrainTreeGypseeum,
    BrainTreeOstrinum,
    BrainTreeViride,
    BrainTreeLividum,
    BrainTreeAureum,
    BrainTreePuniceum,
    BrainTreeLindigoticum,

    // Cactoida
    CactoidaCortexum,
    CactoidaLapis,
    CactoidaVermis,
    CactoidaPullulanta,
    CactoidaPeperatis,

    // Clypeus
    ClypeusLacrimam,
    ClypeusMargaritus,
    ClypeusSpeculumi,

    // Concha
    ConchaRenibus,
    ConchaAureolas,
    ConchaLabiata,
    ConchaBiconcavis,

    // Crystalline Shards
    CrystallineShards,

    // Electricae
    ElectricaePluma,
    ElectricaeRadialem,

    // Fonticulus
    FonticuluaSegmentatus,
    FonticuluaCampestris,
    FonticuluaUpupam,
    FonticuluaLapida,
    FonticuluaFluctus,
    FonticuluaDigitos,

    // Fumerola
    FumerolaCarbosis,
    FumerolaExtremus,
    FumerolaNitris,
    FumerolaAquatis,

    // Fungoida
    FungoidaSetisis,
    FungoidaStabitis,
    FungoidaBullarum,
    FungoidaGelata,

    // Osseus
    OsseusFractus,
    OsseusDiscus,
    OsseusSpiralis,
    OsseusPumice,
    OsseusCornibus,
    OsseusPellebantus,

    // Recepta
    ReceptaUmbrux,
    ReceptaDeltahedronix,
    ReceptaConditivus,

    // Stratum
    StratumExcutitus,
    StratumPaleas,
    StratumLaminamus,
    StratumAraneamus,
    StratumLimaxus,
    StratumCucumisis,
    StratumTectonicas,
    StratumFrigus,

    // Tubus
    TubusConifer,
    TubusSororibus,
    TubusCavas,
    TubusRosarium,
    TubusCompagibus,

    // Frutexa
    FrutexaFlabellum,
    FrutexaAcus,
    FrutexaMetallicum,
    FrutexaFlammasis,
    FrutexaFera,
    FrutexaSponsae,
    FrutexaCollum,

    // Tussock
    TussockPennata,
    TussockVentusa,
    TussockIgnis,
    TussockCultro,
    TussockCatena,
    TussockPennatis,
    TussockSerrati,
    TussockAlbata,
    TussockPropagito,
    TussockDivisa,
    TussockCaputus,
    TussockTriticum,
    TussockStigmasis,
    TussockVirgam,
    TussockCapillum,

    // Thargoid Barnacle
    ThargoidBarnacleCommon,
    ThargoidBarnacleLarge,
    ThargoidBarnacleBarbs,
    ThargoidBarnacleMatrixSubmerged,
    ThargoidBarnacleMatrix,

    // Sinuous Tubers
    SinuousTubersRoseum,
    SinuousTubersPrasinum,
    SinuousTubersAlbidum,
    SinuousTubersCaeruleum,
    SinuousTubersBlatteum,
    SinuousTubersLindigoticum,
    SinuousTubersViolaceum,
    SinuousTubersViride,
}

/// <summary>
/// Extension methods for Species enum.
/// </summary>
public static class SpeciesExtensions
{
    /// <summary>
    /// Gets the base value in credits for a fully scanned species (3 scans complete).
    /// Values are from game data as of Odyssey Update 18.
    /// </summary>
    public static long GetBaseValue(this Species species)
    {
        return species switch
        {
            Species.AleoidaArcus => 7_252_500,
            Species.AleoidaCoronamus => 6_284_600,
            Species.AleoidaSpica => 3_385_200,
            Species.AleoidaLaminiae => 3_385_200,
            Species.AleoidaGravis => 12_934_900,

            Species.AmphoraPlant => 1_628_800,

            Species.AnemoneLuteolum => 1_499_900,
            Species.AnemoneCroceum => 1_499_900,
            Species.AnemonePuniceum => 1_499_900,
            Species.AnemoneRoseum => 1_499_900,
            Species.AnemoneBlatteumBioluminescent => 1_499_900,
            Species.AnemoneRubeumBioluminescent => 1_499_900,
            Species.AnemonePrasinumBioluminescent => 1_499_900,
            Species.AnemoneRoseumBioluminescent => 1_499_900,

            Species.BarkMound => 1_471_900,

            Species.BacteriumAurasus => 1_000_000,
            Species.BacteriumNebulus => 5_289_900,
            Species.BacteriumScopulum => 4_934_500,
            Species.BacteriumAcies => 1_000_000,
            Species.BacteriumVesicula => 1_000_000,
            Species.BacteriumAlcyoneum => 1_658_500,
            Species.BacteriumTela => 1_949_000,
            Species.BacteriumInformem => 8_418_000,
            Species.BacteriumVolu => 7_774_700,
            Species.BacteriumBullaris => 1_152_500,
            Species.BacteriumOmentum => 4_689_800,
            Species.BacteriumCerbrus => 1_689_800,
            Species.BacteriumVerrata => 3_897_000,

            Species.BrainTreeRoseum => 1_593_700,
            Species.BrainTreeGypseeum => 1_593_700,
            Species.BrainTreeOstrinum => 1_593_700,
            Species.BrainTreeViride => 1_593_700,
            Species.BrainTreeLividum => 1_593_700,
            Species.BrainTreeAureum => 1_593_700,
            Species.BrainTreePuniceum => 1_593_700,
            Species.BrainTreeLindigoticum => 1_593_700,

            Species.CactoidaCortexum => 3_667_600,
            Species.CactoidaLapis => 2_483_600,
            Species.CactoidaVermis => 16_202_800,
            Species.CactoidaPullulanta => 3_667_600,
            Species.CactoidaPeperatis => 2_483_600,

            Species.ClypeusLacrimam => 8_418_000,
            Species.ClypeusMargaritus => 11_873_200,
            Species.ClypeusSpeculumi => 16_202_800,

            Species.ConchaRenibus => 4_572_400,
            Species.ConchaAureolas => 7_774_700,
            Species.ConchaLabiata => 2_352_400,
            Species.ConchaBiconcavis => 19_010_800,

            Species.CrystallineShards => 1_628_800,

            Species.ElectricaePluma => 6_284_600,
            Species.ElectricaeRadialem => 6_284_600,

            Species.FonticuluaSegmentatus => 19_010_800,
            Species.FonticuluaCampestris => 1_000_000,
            Species.FonticuluaUpupam => 5_727_600,
            Species.FonticuluaLapida => 3_111_000,
            Species.FonticuluaFluctus => 20_000_000,
            Species.FonticuluaDigitos => 1_804_100,

            Species.FumerolaCarbosis => 6_284_600,
            Species.FumerolaExtremus => 16_202_800,
            Species.FumerolaNitris => 7_500_900,
            Species.FumerolaAquatis => 6_284_600,

            Species.FungoidaSetisis => 1_670_100,
            Species.FungoidaStabitis => 2_680_300,
            Species.FungoidaBullarum => 3_703_200,
            Species.FungoidaGelata => 3_330_300,

            Species.OsseusFractus => 4_027_800,
            Species.OsseusDiscus => 12_934_900,
            Species.OsseusSpiralis => 2_404_700,
            Species.OsseusPumice => 3_156_300,
            Species.OsseusCornibus => 1_483_000,
            Species.OsseusPellebantus => 9_739_000,

            Species.ReceptaUmbrux => 12_934_900,
            Species.ReceptaDeltahedronix => 16_202_800,
            Species.ReceptaConditivus => 14_313_700,

            Species.StratumExcutitus => 2_448_900,
            Species.StratumPaleas => 1_362_000,
            Species.StratumLaminamus => 2_788_300,
            Species.StratumAraneamus => 2_448_900,
            Species.StratumLimaxus => 1_362_000,
            Species.StratumCucumisis => 16_202_800,
            Species.StratumTectonicas => 19_010_800,
            Species.StratumFrigus => 2_637_500,

            Species.TubusConifer => 2_415_500,
            Species.TubusSororibus => 5_727_600,
            Species.TubusCavas => 11_873_200,
            Species.TubusRosarium => 2_637_500,
            Species.TubusCompagibus => 7_774_700,

            Species.FrutexaFlabellum => 1_808_900,
            Species.FrutexaAcus => 7_774_700,
            Species.FrutexaMetallicum => 1_632_500,
            Species.FrutexaFlammasis => 10_326_000,
            Species.FrutexaFera => 1_632_500,
            Species.FrutexaSponsae => 5_988_000,
            Species.FrutexaCollum => 1_639_800,

            Species.TussockPennata => 5_853_800,
            Species.TussockVentusa => 3_227_700,
            Species.TussockIgnis => 1_849_000,
            Species.TussockCultro => 1_766_600,
            Species.TussockCatena => 1_766_600,
            Species.TussockPennatis => 1_000_000,
            Species.TussockSerrati => 4_447_100,
            Species.TussockAlbata => 3_252_500,
            Species.TussockPropagito => 1_000_000,
            Species.TussockDivisa => 1_766_600,
            Species.TussockCaputus => 3_472_400,
            Species.TussockTriticum => 7_774_700,
            Species.TussockStigmasis => 19_010_800,
            Species.TussockVirgam => 14_313_700,
            Species.TussockCapillum => 7_025_800,

            Species.ThargoidBarnacleCommon => 0,
            Species.ThargoidBarnacleLarge => 0,
            Species.ThargoidBarnacleBarbs => 0,
            Species.ThargoidBarnacleMatrixSubmerged => 0,
            Species.ThargoidBarnacleMatrix => 2_313_500,

            Species.SinuousTubersRoseum => 1_514_500,
            Species.SinuousTubersPrasinum => 1_514_500,
            Species.SinuousTubersAlbidum => 1_514_500,
            Species.SinuousTubersCaeruleum => 1_514_500,
            Species.SinuousTubersBlatteum => 1_514_500,
            Species.SinuousTubersLindigoticum => 1_514_500,
            Species.SinuousTubersViolaceum => 1_514_500,
            Species.SinuousTubersViride => 1_514_500,

            _ => 0
        };
    }
}
