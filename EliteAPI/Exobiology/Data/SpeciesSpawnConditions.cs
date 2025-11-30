using System.Collections.Generic;
using EliteAPI.Exobiology.Models;
using static EliteAPI.Exobiology.Models.SpawnCondition;

namespace EliteAPI.Exobiology.Data;

/// <summary>
/// Contains spawn conditions for all exobiology species in Elite Dangerous.
/// Ported from EDMC-BioScan project (https://github.com/Baleur/EDMC-BioScan)
/// Last updated: 2025-11-29
/// </summary>
public static class SpeciesSpawnConditions
{
    /// <summary>
    /// Dictionary mapping each species to its spawn condition requirements.
    /// </summary>
    public static readonly Dictionary<Species, SpawnCondition> Conditions = new()
    {
        // ============================================================================
        // BACTERIUM (13 species)
        // ============================================================================

        [Species.BacteriumAurasus] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody, PlanetClass.RockyIceBody),
                new MinGravity(0.039f),
                new MaxGravity(0.608f),
                new MinTemperature(145.0f),
                new MaxTemperature(400.0f)
            )
        ),

        [Species.BacteriumNebulus] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Helium),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.4f),
                new MaxGravity(0.55f),
                new MinTemperature(20.0f),
                new MaxTemperature(21.0f),
                new MinPressure(0.067f)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Helium),
                new RequiresPlanetClass(PlanetClass.RockyIceBody),
                new MinGravity(0.4f),
                new MaxGravity(0.7f),
                new MinTemperature(20.0f),
                new MaxTemperature(21.0f),
                new MinPressure(0.067f)
            )
        ),

        [Species.BacteriumScopulum] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.15f),
                new MaxGravity(0.26f),
                new MinTemperature(56.0f),
                new MaxTemperature(150.0f),
                new RequiresVolcanism(VolcanismType.CarbonDioxideGeysers, VolcanismType.MethaneMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Helium),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.48f),
                new MaxGravity(0.51f),
                new MinTemperature(20.0f),
                new MaxTemperature(21.0f),
                new MinPressure(0.075f),
                new RequiresVolcanism(VolcanismType.MethaneMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.025f),
                new MaxGravity(0.047f),
                new MinTemperature(84.0f),
                new MaxTemperature(110.0f),
                new MinPressure(0.03f),
                new RequiresVolcanism(VolcanismType.MethaneMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Neon, AtmosphereType.NeonRich),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.025f),
                new MaxGravity(0.61f),
                new MinTemperature(20.0f),
                new MaxTemperature(65.0f),
                new MaxPressure(0.008f),
                new RequiresVolcanism(VolcanismType.CarbonDioxideGeysers, VolcanismType.MethaneMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Nitrogen),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.2f),
                new MaxGravity(0.3f),
                new MinTemperature(60.0f),
                new MaxTemperature(70.0f),
                new RequiresVolcanism(VolcanismType.CarbonDioxideGeysers, VolcanismType.MethaneMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Oxygen),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.27f),
                new MaxGravity(0.40f),
                new MinTemperature(150.0f),
                new MaxTemperature(220.0f),
                new MinPressure(0.01f),
                new RequiresVolcanism(VolcanismType.CarbonDioxideGeysers, VolcanismType.MethaneMagma)
            )
        ),

        [Species.BacteriumAcies] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Neon),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.255f),
                new MaxGravity(0.61f),
                new MinTemperature(20.0f),
                new MaxTemperature(61.0f),
                new MaxPressure(0.01f)
            )
        ),

        [Species.BacteriumVesicula] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon),
                new MinGravity(0.027f),
                new MaxGravity(0.51f),
                new MinTemperature(50.0f),
                new MaxTemperature(245.0f)
            )
        ),

        [Species.BacteriumAlcyoneum] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.376f),
                new MinTemperature(152.0f),
                new MaxTemperature(177.0f),
                new MaxPressure(0.0135f)
            )
        ),

        [Species.BacteriumTela] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.045f),
                new MaxGravity(0.45f),
                new MinTemperature(50.0f),
                new MaxTemperature(200.0f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.ArgonRich),
                new MinGravity(0.24f),
                new MaxGravity(0.45f),
                new MinTemperature(50.0f),
                new MaxTemperature(150.0f),
                new MaxPressure(0.05f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new MinGravity(0.025f),
                new MaxGravity(0.23f),
                new MinTemperature(165.0f),
                new MaxTemperature(177.0f),
                new MinPressure(0.0025f),
                new MaxPressure(0.02f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new MinGravity(0.45f),
                new MaxGravity(0.61f),
                new MinTemperature(300.0f),
                new MaxTemperature(500.0f),
                new MinPressure(0.006f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide, AtmosphereType.CarbonDioxideRich),
                new MinGravity(0.26f),
                new MaxGravity(0.57f),
                new MinTemperature(167.0f),
                new MaxTemperature(300.0f),
                new MinPressure(0.006f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Helium),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.025f),
                new MaxGravity(0.61f),
                new MinTemperature(20.0f),
                new MaxTemperature(21.0f),
                new MinPressure(0.067f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.026f),
                new MaxGravity(0.126f),
                new MinTemperature(80.0f),
                new MaxTemperature(109.0f),
                new MinPressure(0.012f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Neon, AtmosphereType.NeonRich),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.27f),
                new MaxGravity(0.61f),
                new MinTemperature(20.0f),
                new MaxTemperature(95.0f),
                new MaxPressure(0.008f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Nitrogen),
                new MinGravity(0.21f),
                new MaxGravity(0.35f),
                new MinTemperature(55.0f),
                new MaxTemperature(80.0f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Oxygen),
                new MinGravity(0.23f),
                new MaxGravity(0.5f),
                new MinTemperature(150.0f),
                new MaxTemperature(240.0f),
                new MinPressure(0.01f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new MinGravity(0.18f),
                new MaxGravity(0.61f),
                new MinTemperature(148.0f),
                new MaxTemperature(550.0f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new MinGravity(0.18f),
                new MaxGravity(0.61f),
                new MinTemperature(300.0f),
                new MaxTemperature(550.0f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.5f),
                new MaxGravity(0.55f),
                new MinTemperature(500.0f),
                new MaxTemperature(650.0f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.063f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.WaterRich),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.315f),
                new MaxGravity(0.44f),
                new MinTemperature(220.0f),
                new MaxTemperature(330.0f),
                new MinPressure(0.01f),
                new AnyVolcanism()
            )
        ),

        [Species.BacteriumInformem] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Nitrogen),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.05f),
                new MaxGravity(0.6f),
                new MinTemperature(42.5f),
                new MaxTemperature(151.0f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Nitrogen),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.17f),
                new MaxGravity(0.63f),
                new MinTemperature(50.0f),
                new MaxTemperature(90.0f)
            )
        ),

        [Species.BacteriumVolu] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Oxygen),
                new MinGravity(0.239f),
                new MaxGravity(0.61f),
                new MinTemperature(143.5f),
                new MaxTemperature(246.0f),
                new MinPressure(0.013f)
            )
        ),

        [Species.BacteriumBullaris] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new MinGravity(0.0245f),
                new MaxGravity(0.35f),
                new MinTemperature(67.0f),
                new MaxTemperature(109.0f)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.MethaneRich),
                new MinGravity(0.44f),
                new MaxGravity(0.6f),
                new MinTemperature(74.0f),
                new MaxTemperature(141.0f),
                new MinPressure(0.01f),
                new MaxPressure(0.05f),
                new NoVolcanism(),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody)
            )
        ),

        [Species.BacteriumOmentum] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.045f),
                new MaxGravity(0.45f),
                new MinTemperature(50.0f),
                new RequiresVolcanism(VolcanismType.NitrogenMagma, VolcanismType.AmmoniaGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.ArgonRich),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.23f),
                new MaxGravity(0.45f),
                new MinTemperature(80.0f),
                new MaxTemperature(90.0f),
                new MinPressure(0.01f),
                new RequiresVolcanism(VolcanismType.NitrogenMagma, VolcanismType.AmmoniaGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Helium),
                new MinGravity(0.4f),
                new MaxGravity(0.51f),
                new MinTemperature(20.0f),
                new MaxTemperature(21.0f),
                new MinPressure(0.065f),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new RequiresVolcanism(VolcanismType.NitrogenMagma, VolcanismType.AmmoniaGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new MinGravity(0.0265f),
                new MaxGravity(0.0455f),
                new MinTemperature(84.0f),
                new MaxTemperature(108.0f),
                new MinPressure(0.035f),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new RequiresVolcanism(VolcanismType.NitrogenMagma, VolcanismType.AmmoniaGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Neon),
                new MinGravity(0.31f),
                new MaxGravity(0.6f),
                new MinTemperature(20.0f),
                new MaxTemperature(61.0f),
                new MaxPressure(0.0065f),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new RequiresVolcanism(VolcanismType.NitrogenMagma, VolcanismType.AmmoniaGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.NeonRich),
                new MinGravity(0.27f),
                new MaxGravity(0.61f),
                new MinTemperature(20.0f),
                new MaxTemperature(93.0f),
                new MinPressure(0.0027f),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new RequiresVolcanism(VolcanismType.NitrogenMagma, VolcanismType.AmmoniaGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Nitrogen),
                new MinGravity(0.2f),
                new MaxGravity(0.26f),
                new MinTemperature(60.0f),
                new MaxTemperature(80.0f),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new RequiresVolcanism(VolcanismType.NitrogenMagma, VolcanismType.AmmoniaGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.WaterRich),
                new MinGravity(0.38f),
                new MaxGravity(0.45f),
                new MinTemperature(190.0f),
                new MaxTemperature(320.0f),
                new MinPressure(0.07f),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new RequiresVolcanism(VolcanismType.NitrogenMagma, VolcanismType.AmmoniaGeysers)
            )
        ),

        [Species.BacteriumCerbrus] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new MinGravity(0.042f),
                new MaxGravity(0.605f),
                new MinTemperature(132.0f),
                new MaxTemperature(500.0f),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new MinGravity(0.04f),
                new MaxGravity(0.064f),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new MinGravity(0.04f),
                new MaxGravity(0.064f),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.WaterRich),
                new MinGravity(0.4f),
                new MaxGravity(0.5f),
                new MinTemperature(240.0f),
                new MaxTemperature(320.0f),
                new RequiresPlanetClass(PlanetClass.RockyIceBody),
                new NoVolcanism()
            )
        ),

        [Species.BacteriumVerrata] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.IcyBody),
                new MinGravity(0.03f),
                new MaxGravity(0.09f),
                new MinTemperature(160.0f),
                new MaxTemperature(180.0f),
                new MaxPressure(0.0135f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon),
                new RequiresPlanetClass(PlanetClass.RockyIceBody, PlanetClass.IcyBody),
                new MinGravity(0.165f),
                new MaxGravity(0.33f),
                new MinTemperature(57.5f),
                new MaxTemperature(145.0f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.ArgonRich),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.04f),
                new MaxGravity(0.08f),
                new MinTemperature(80.0f),
                new MaxTemperature(90.0f),
                new MaxPressure(0.01f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide, AtmosphereType.CarbonDioxideRich),
                new RequiresPlanetClass(PlanetClass.RockyIceBody, PlanetClass.IcyBody),
                new MinGravity(0.25f),
                new MaxGravity(0.32f),
                new MinTemperature(167.0f),
                new MaxTemperature(240.0f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Helium),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.49f),
                new MaxGravity(0.53f),
                new MinTemperature(20.0f),
                new MaxTemperature(21.0f),
                new MinPressure(0.065f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Neon),
                new RequiresPlanetClass(PlanetClass.RockyIceBody, PlanetClass.IcyBody),
                new MinGravity(0.29f),
                new MaxGravity(0.61f),
                new MinTemperature(20.0f),
                new MaxTemperature(51.0f),
                new MaxPressure(0.075f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.NeonRich),
                new RequiresPlanetClass(PlanetClass.RockyIceBody, PlanetClass.IcyBody),
                new MinGravity(0.43f),
                new MaxGravity(0.61f),
                new MinTemperature(20.0f),
                new MaxTemperature(65.0f),
                new MinPressure(0.005f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Nitrogen),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.205f),
                new MaxGravity(0.241f),
                new MinTemperature(60.0f),
                new MaxTemperature(80.0f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Oxygen),
                new RequiresPlanetClass(PlanetClass.RockyIceBody, PlanetClass.IcyBody),
                new MinGravity(0.24f),
                new MaxGravity(0.35f),
                new MinTemperature(154.0f),
                new MaxTemperature(220.0f),
                new MinPressure(0.01f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new MinGravity(0.04f),
                new MaxGravity(0.054f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            )
        ),

        // ============================================================================
        // ALEOIDA (5 species)
        // ============================================================================

        [Species.AleoidaArcus] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(175.0f),
                new MaxTemperature(180.0f),
                new MinPressure(0.0161f),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new NoVolcanism()
            )
        ),

        [Species.AleoidaCoronamus] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(180.0f),
                new MaxTemperature(190.0f),
                new MinPressure(0.025f),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new NoVolcanism()
            )
        ),

        [Species.AleoidaGravis] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(190.0f),
                new MaxTemperature(197.0f),
                new MinPressure(0.054f),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new NoVolcanism()
            )
        ),

        [Species.AleoidaSpica] = new All(
            new RequiresAtmosphere(AtmosphereType.Ammonia),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(170.0f),
            new MaxTemperature(177.0f),
            new MaxPressure(0.0135f),
            new RequiresRegion(GalacticRegion.Outer, GalacticRegion.Perseus, GalacticRegion.ScutumCentaurus)
        ),

        [Species.AleoidaLaminiae] = new All(
            new RequiresAtmosphere(AtmosphereType.Ammonia),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(152.0f),
            new MaxTemperature(177.0f),
            new MaxPressure(0.0135f),
            new RequiresRegion(GalacticRegion.OrionCygnus, GalacticRegion.SagittariusCarina)
        ),

        // ============================================================================
        // TUSSOCK (15 species)
        // ============================================================================

        [Species.TussockPennatis] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(147.0f),
                new MaxTemperature(197.0f),
                new MinPressure(0.00289f),
                new NoVolcanism()
                // Region: outer
            )
        ),

        [Species.TussockStigmasis] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(132.0f),
                new MaxTemperature(180.0f),
                new MaxPressure(0.01f)
            )
        ),

        [Species.TussockVirgam] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.065f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.065f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            )
        ),

        [Species.TussockCapillum] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon),
                new MinGravity(0.22f),
                new MaxGravity(0.276f),
                new MinTemperature(80.0f),
                new MaxTemperature(129.0f),
                new RequiresPlanetClass(PlanetClass.RockyIceBody)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new MinGravity(0.033f),
                new MaxGravity(0.276f),
                new MinTemperature(80.0f),
                new MaxTemperature(110.0f),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody)
            )
        ),

        // Other Tussock species require galactic region support - marked as special
        [Species.TussockPennata] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.09f),
            new MinTemperature(146.0f),
            new MaxTemperature(154.0f),
            new MinPressure(0.00289f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.SagittariusCarineCore9, GalacticRegion.PerseusCore, GalacticRegion.OrionCygnusCore)
        ),

        [Species.TussockVentusa] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.13f),
            new MinTemperature(155.0f),
            new MaxTemperature(160.0f),
            new MinPressure(0.00289f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.SagittariusCarineCore9, GalacticRegion.PerseusCore, GalacticRegion.OrionCygnusCore)
        ),

        [Species.TussockIgnis] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.2f),
            new MinTemperature(161.0f),
            new MaxTemperature(170.0f),
            new MinPressure(0.00289f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.SagittariusCarineCore9, GalacticRegion.PerseusCore, GalacticRegion.OrionCygnusCore)
        ),

        [Species.TussockCultro] = new All(
            new RequiresAtmosphere(AtmosphereType.Ammonia),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(152.0f),
            new MaxTemperature(177.0f),
            new MaxPressure(0.0135f),
            new RequiresRegion(GalacticRegion.OrionCygnus)
        ),

        [Species.TussockCatena] = new All(
            new RequiresAtmosphere(AtmosphereType.Ammonia),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(152.0f),
            new MaxTemperature(177.0f),
            new MaxPressure(0.0135f),
            new RequiresRegion(GalacticRegion.ScutumCentaurusCore)
        ),

        [Species.TussockSerrati] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.042f),
            new MaxGravity(0.23f),
            new MinTemperature(171.0f),
            new MaxTemperature(174.0f),
            new MinPressure(0.01f),
            new MaxPressure(0.071f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.SagittariusCarineCore9, GalacticRegion.PerseusCore, GalacticRegion.OrionCygnusCore)
        ),

        [Species.TussockAlbata] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.042f),
            new MaxGravity(0.276f),
            new MinTemperature(175.0f),
            new MaxTemperature(180.0f),
            new MinPressure(0.016f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.SagittariusCarineCore9, GalacticRegion.PerseusCore, GalacticRegion.OrionCygnusCore)
        ),

        [Species.TussockPropagito] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(145.0f),
            new MaxTemperature(197.0f),
            new MinPressure(0.00289f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.ScutumCentaurus)
        ),

        [Species.TussockDivisa] = new All(
            new RequiresAtmosphere(AtmosphereType.Ammonia),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.042f),
            new MaxGravity(0.276f),
            new MinTemperature(152.0f),
            new MaxTemperature(177.0f),
            new MaxPressure(0.0135f),
            new RequiresRegion(GalacticRegion.PerseusCore)
        ),

        [Species.TussockCaputus] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.041f),
            new MaxGravity(0.27f),
            new MinTemperature(181.0f),
            new MaxTemperature(190.0f),
            new MinPressure(0.0275f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.SagittariusCarineCore9, GalacticRegion.PerseusCore, GalacticRegion.OrionCygnusCore)
        ),

        [Species.TussockTriticum] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(191.0f),
            new MaxTemperature(197.0f),
            new MinPressure(0.058f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.SagittariusCarineCore9, GalacticRegion.PerseusCore, GalacticRegion.OrionCygnusCore)
        ),

        // ============================================================================
        // CACTOIDA (5 species)
        // ============================================================================

        [Species.CactoidaVermis] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new MinGravity(0.265f),
                new MaxGravity(0.276f),
                new MinTemperature(160.0f),
                new MaxTemperature(210.0f),
                new MaxPressure(0.005f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            )
        ),

        // Other Cactoida species require galactic region support
        [Species.CactoidaCortexum] = new All(
            new RequiresAtmosphere(AtmosphereType.Ammonia),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(152.0f),
            new MaxTemperature(177.0f),
            new MaxPressure(0.0135f),
            new RequiresRegion(GalacticRegion.OrionCygnus)
        ),

        [Species.CactoidaLapis] = new All(
            new RequiresAtmosphere(AtmosphereType.Ammonia),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(160.0f),
            new MaxTemperature(177.0f),
            new MaxPressure(0.0135f),
            new RequiresRegion(GalacticRegion.SagittariusCarina)
        ),

        [Species.CactoidaPullulanta] = new All(
            new RequiresAtmosphere(AtmosphereType.Ammonia),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(152.0f),
            new MaxTemperature(177.0f),
            new MaxPressure(0.0135f),
            new RequiresRegion(GalacticRegion.Perseus)
        ),

        [Species.CactoidaPeperatis] = new All(
            new RequiresAtmosphere(AtmosphereType.Ammonia),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(152.0f),
            new MaxTemperature(177.0f),
            new MaxPressure(0.0135f),
            new RequiresRegion(GalacticRegion.ScutumCentaurus)
        ),

        // ============================================================================
        // CLYPEUS (3 species)
        // ============================================================================

        [Species.ClypeusLacrimam] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(190.0f),
                new MaxTemperature(197.0f),
                new MinPressure(0.054f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            )
        ),

        [Species.ClypeusMargaritus] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(190.0f),
                new MaxTemperature(197.0f),
                new MinPressure(0.054f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new NoVolcanism()
            )
        ),

        [Species.ClypeusSpeculumi] = new Special("Requires distance > 2000 LS from arrival"),

        // ============================================================================
        // CONCHA (4 species)
        // ============================================================================

        [Species.ConchaRenibus] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.045f),
                new MinTemperature(176.0f),
                new MaxTemperature(177.0f),
                new RequiresVolcanism(VolcanismType.SilicateMagma, VolcanismType.MetallicMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(180.0f),
                new MaxTemperature(197.0f),
                new MinPressure(0.025f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.15f),
                new MinTemperature(78.0f),
                new MaxTemperature(100.0f),
                new MinPressure(0.01f),
                new RequiresVolcanism(VolcanismType.SilicateMagma, VolcanismType.MetallicMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.65f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.65f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            )
        ),

        [Species.ConchaAureolas] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(152.0f),
                new MaxTemperature(177.0f),
                new MaxPressure(0.0135f)
            )
        ),

        [Species.ConchaLabiata] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(150.0f),
                new MaxTemperature(200.0f),
                new MinPressure(0.002f),
                new NoVolcanism()
            )
        ),

        [Species.ConchaBiconcavis] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Nitrogen),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.053f),
                new MaxGravity(0.275f),
                new MinTemperature(42.0f),
                new MaxTemperature(52.0f),
                new MaxPressure(0.0047f),
                new NoVolcanism()
            )
        ),

        // ============================================================================
        // ELECTRICAE (2 species)
        // ============================================================================

        [Species.ElectricaePluma] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon, AtmosphereType.ArgonRich),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.025f),
                new MaxGravity(0.276f),
                new MinTemperature(50.0f),
                new MaxTemperature(150.0f),
                new ParentStarClass(StarClass.A, StarClass.N, StarClass.D, StarClass.H, StarClass.AeBe)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Neon, AtmosphereType.NeonRich),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.26f),
                new MaxGravity(0.276f),
                new MinTemperature(20.0f),
                new MaxTemperature(70.0f),
                new MaxPressure(0.005f),
                new ParentStarClass(StarClass.A, StarClass.N, StarClass.D, StarClass.H, StarClass.AeBe)
            )
        ),

        [Species.ElectricaeRadialem] = new Special("Requires nebula proximity"),

        // ============================================================================
        // FONTICULUA (6 species)
        // ============================================================================

        [Species.FonticuluaSegmentatus] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Neon, AtmosphereType.NeonRich),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.25f),
                new MaxGravity(0.276f),
                new MinTemperature(50.0f),
                new MaxTemperature(75.0f),
                new MaxPressure(0.006f),
                new NoVolcanism()
            )
        ),

        [Species.FonticuluaCampestris] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.027f),
                new MaxGravity(0.276f),
                new MinTemperature(50.0f),
                new MaxTemperature(150.0f)
            )
        ),

        [Species.FonticuluaUpupam] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.ArgonRich),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.209f),
                new MaxGravity(0.276f),
                new MinTemperature(61.0f),
                new MaxTemperature(125.0f),
                new MinPressure(0.0175f)
            )
        ),

        [Species.FonticuluaLapida] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Nitrogen),
                new MinGravity(0.19f),
                new MaxGravity(0.276f),
                new MinTemperature(50.0f),
                new MaxTemperature(81.0f),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody)
            )
        ),

        [Species.FonticuluaFluctus] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Oxygen),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.235f),
                new MaxGravity(0.276f),
                new MinTemperature(143.0f),
                new MaxTemperature(200.0f),
                new MinPressure(0.012f)
            )
        ),

        [Species.FonticuluaDigitos] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.025f),
                new MaxGravity(0.07f),
                new MinTemperature(83.0f),
                new MaxTemperature(109.0f),
                new MinPressure(0.03f)
            )
        ),

        // ============================================================================
        // FRUTEXA (7 species)
        // ============================================================================

        [Species.FrutexaMetallicum] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(152.0f),
                new MaxTemperature(176.0f),
                new MaxPressure(0.01f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(146.0f),
                new MaxTemperature(197.0f),
                new MinPressure(0.002f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody),
                new MinGravity(0.05f),
                new MaxGravity(0.1f),
                new MinTemperature(100.0f),
                new MaxTemperature(300.0f)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.07f),
                new MaxTemperature(400.0f),
                new MaxPressure(0.07f),
                new NoVolcanism()
            )
        ),

        [Species.FrutexaSponsae] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new MinGravity(0.04f),
                new MaxGravity(0.056f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new MinGravity(0.04f),
                new MaxGravity(0.056f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            )
        ),

        [Species.FrutexaCollum] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(132.0f),
                new MaxTemperature(215.0f),
                new MaxPressure(0.004f)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody),
                new MinGravity(0.265f),
                new MaxGravity(0.276f),
                new MinTemperature(132.0f),
                new MaxTemperature(135.0f),
                new MaxPressure(0.004f),
                new NoVolcanism()
            )
        ),

        // Other Frutexa species require galactic region support
        [Species.FrutexaFlabellum] = new All(
            new RequiresAtmosphere(AtmosphereType.Ammonia),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(152.0f),
            new MaxTemperature(177.0f),
            new MaxPressure(0.0135f),
            new NotInRegion(GalacticRegion.ScutumCentaurus)
        ),

        [Species.FrutexaAcus] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody),
            new MinGravity(0.04f),
            new MaxGravity(0.237f),
            new MinTemperature(146.0f),
            new MaxTemperature(197.0f),
            new MinPressure(0.0029f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.OrionCygnus)
        ),

        [Species.FrutexaFlammasis] = new All(
            new RequiresAtmosphere(AtmosphereType.Ammonia),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(152.0f),
            new MaxTemperature(177.0f),
            new MaxPressure(0.0135f),
            new RequiresRegion(GalacticRegion.ScutumCentaurus)
        ),

        [Species.FrutexaFera] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(146.0f),
            new MaxTemperature(197.0f),
            new MinPressure(0.003f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.Outer)
        ),

        // ============================================================================
        // FUMEROLA (4 species)
        // ============================================================================

        [Species.FumerolaCarbosis] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.168f),
                new MaxGravity(0.276f),
                new MinTemperature(57.0f),
                new MaxTemperature(150.0f),
                new RequiresVolcanism(VolcanismType.CarbonDioxideGeysers, VolcanismType.MethaneMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.025f),
                new MaxGravity(0.047f),
                new MinTemperature(84.0f),
                new MaxTemperature(110.0f),
                new MinPressure(0.03f),
                new RequiresVolcanism(VolcanismType.MethaneMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Neon),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.26f),
                new MaxGravity(0.276f),
                new MinTemperature(40.0f),
                new MaxTemperature(60.0f),
                new RequiresVolcanism(VolcanismType.CarbonDioxideGeysers, VolcanismType.MethaneMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Nitrogen),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.2f),
                new MaxGravity(0.276f),
                new MinTemperature(57.0f),
                new MaxTemperature(70.0f),
                new RequiresVolcanism(VolcanismType.CarbonDioxideGeysers, VolcanismType.MethaneMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Oxygen),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.26f),
                new MaxGravity(0.276f),
                new MinTemperature(160.0f),
                new MaxTemperature(180.0f),
                new RequiresVolcanism(VolcanismType.CarbonDioxideGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.185f),
                new MaxGravity(0.276f),
                new MinTemperature(149.0f),
                new MaxTemperature(272.0f),
                new RequiresVolcanism(VolcanismType.CarbonDioxideGeysers, VolcanismType.MethaneMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia, AtmosphereType.ArgonRich, AtmosphereType.CarbonDioxideRich),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MaxGravity(0.276f),
                new RequiresVolcanism(VolcanismType.CarbonDioxideGeysers)
            )
        ),

        [Species.FumerolaExtremus] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.09f),
                new MinTemperature(161.0f),
                new MaxTemperature(177.0f),
                new MaxPressure(0.0135f),
                new RequiresVolcanism(VolcanismType.SilicateMagma, VolcanismType.MetallicMagma, VolcanismType.RockyMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.07f),
                new MaxGravity(0.276f),
                new MinTemperature(50.0f),
                new MaxTemperature(121.0f),
                new RequiresVolcanism(VolcanismType.SilicateMagma, VolcanismType.MetallicMagma, VolcanismType.RockyMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.025f),
                new MaxGravity(0.127f),
                new MinTemperature(77.0f),
                new MaxTemperature(109.0f),
                new MinPressure(0.01f),
                new RequiresVolcanism(VolcanismType.SilicateMagma, VolcanismType.MetallicMagma, VolcanismType.RockyMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.07f),
                new MaxGravity(0.276f),
                new MinTemperature(54.0f),
                new MaxTemperature(210.0f),
                new RequiresVolcanism(VolcanismType.SilicateMagma, VolcanismType.MetallicMagma, VolcanismType.RockyMagma)
            )
        ),

        [Species.FumerolaNitris] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Neon),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(30.0f),
                new MaxTemperature(129.0f),
                new RequiresVolcanism(VolcanismType.NitrogenMagma, VolcanismType.AmmoniaGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon, AtmosphereType.ArgonRich, AtmosphereType.NeonRich),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.044f),
                new MaxGravity(0.276f),
                new MinTemperature(50.0f),
                new MaxTemperature(141.0f),
                new RequiresVolcanism(VolcanismType.NitrogenMagma, VolcanismType.AmmoniaGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.025f),
                new MaxGravity(0.1f),
                new MinTemperature(83.0f),
                new MaxTemperature(109.0f),
                new RequiresVolcanism(VolcanismType.NitrogenMagma)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Nitrogen),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.21f),
                new MaxGravity(0.276f),
                new MinTemperature(60.0f),
                new MaxTemperature(81.0f),
                new RequiresVolcanism(VolcanismType.NitrogenMagma, VolcanismType.AmmoniaGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Oxygen),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MaxGravity(0.276f),
                new MinTemperature(150.0f),
                new RequiresVolcanism(VolcanismType.NitrogenMagma, VolcanismType.AmmoniaGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.21f),
                new MaxGravity(0.276f),
                new MinTemperature(160.0f),
                new MaxTemperature(250.0f),
                new RequiresVolcanism(VolcanismType.NitrogenMagma, VolcanismType.AmmoniaGeysers)
            )
        ),

        [Species.FumerolaAquatis] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody, PlanetClass.RockyBody),
                new MinGravity(0.028f),
                new MaxGravity(0.276f),
                new MinTemperature(161.0f),
                new MaxTemperature(177.0f),
                new MinPressure(0.002f),
                new MaxPressure(0.02f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon, AtmosphereType.ArgonRich),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody),
                new MinGravity(0.166f),
                new MaxGravity(0.276f),
                new MinTemperature(57.0f),
                new MaxTemperature(150.0f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.25f),
                new MaxGravity(0.276f),
                new MinTemperature(160.0f),
                new MaxTemperature(180.0f),
                new MinPressure(0.01f),
                new MaxPressure(0.03f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(80.0f),
                new MaxTemperature(100.0f),
                new MinPressure(0.01f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Neon),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.26f),
                new MaxGravity(0.276f),
                new MinTemperature(20.0f),
                new MaxTemperature(60.0f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Nitrogen),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.195f),
                new MaxGravity(0.245f),
                new MinTemperature(56.0f),
                new MaxTemperature(80.0f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Oxygen),
                new RequiresPlanetClass(PlanetClass.IcyBody),
                new MinGravity(0.23f),
                new MaxGravity(0.276f),
                new MinTemperature(153.0f),
                new MaxTemperature(190.0f),
                new MinPressure(0.01f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new RequiresPlanetClass(PlanetClass.IcyBody, PlanetClass.RockyIceBody, PlanetClass.RockyBody),
                new MinGravity(0.18f),
                new MaxGravity(0.276f),
                new MinTemperature(150.0f),
                new MaxTemperature(270.0f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new MinGravity(0.04f),
                new MaxGravity(0.06f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            )
        ),

        // ============================================================================
        // FUNGOIDA (4 species)
        // ============================================================================

        [Species.FungoidaSetisis] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(152.0f),
                new MaxTemperature(177.0f),
                new MaxPressure(0.0135f)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new RequiresPlanetClass(PlanetClass.RockyIceBody),
                new MinGravity(0.033f),
                new MaxGravity(0.276f),
                new MinTemperature(68.0f),
                new MaxTemperature(109.0f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.033f),
                new MaxGravity(0.276f),
                new MinTemperature(67.0f),
                new MaxTemperature(109.0f)
            )
        ),

        [Species.FungoidaBullarum] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon),
                new MinGravity(0.058f),
                new MaxGravity(0.276f),
                new MinTemperature(50.0f),
                new MaxTemperature(129.0f),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Nitrogen),
                new MinGravity(0.155f),
                new MaxGravity(0.276f),
                new MinTemperature(50.0f),
                new MaxTemperature(70.0f),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new NoVolcanism()
            )
        ),

        // FungoidaStabitis and FungoidaGelata require galactic region support
        // Fungoida Stabitis and Gelata require complex multi-ruleset conditions - using simplified region filters
        // Note: Full spawn conditions include multiple atmosphere/volcanism/gravity combinations
        [Species.FungoidaStabitis] = new RequiresRegion(GalacticRegion.OrionCygnus),
        [Species.FungoidaGelata] = new NotInRegion(GalacticRegion.OrionCygnusCore),

        // ============================================================================
        // OSSEUS (6 species)
        // ============================================================================

        [Species.OsseusPumice] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.059f),
                new MaxGravity(0.276f),
                new MinTemperature(50.0f),
                new MaxTemperature(135.0f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon),
                new RequiresPlanetClass(PlanetClass.RockyIceBody),
                new MinGravity(0.059f),
                new MaxGravity(0.276f),
                new MinTemperature(50.0f),
                new MaxTemperature(135.0f),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.ArgonRich),
                new RequiresPlanetClass(PlanetClass.RockyIceBody),
                new MinGravity(0.035f),
                new MaxGravity(0.276f),
                new MinTemperature(60.0f),
                new MaxTemperature(80.5f),
                new MinPressure(0.03f),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.033f),
                new MaxGravity(0.276f),
                new MinTemperature(67.0f),
                new MaxTemperature(109.0f)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Nitrogen),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.05f),
                new MaxGravity(0.276f),
                new MinTemperature(42.0f),
                new MaxTemperature(70.1f),
                new NoVolcanism()
            )
        ),

        [Species.OsseusSpiralis] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.276f),
                new MinTemperature(160.0f),
                new MaxTemperature(177.0f),
                new MaxPressure(0.0135f)
            )
        ),

        [Species.OsseusDiscus] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.RockyIceBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.088f),
                new MinTemperature(161.0f),
                new MaxTemperature(177.0f),
                new MaxPressure(0.0135f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon),
                new RequiresPlanetClass(PlanetClass.RockyIceBody),
                new MinGravity(0.2f),
                new MaxGravity(0.276f),
                new MinTemperature(65.0f),
                new MaxTemperature(120.0f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Methane),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new MinGravity(0.04f),
                new MaxGravity(0.127f),
                new MinTemperature(80.0f),
                new MaxTemperature(110.0f),
                new MinPressure(0.012f),
                new AnyVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
                new MinGravity(0.04f),
                new MaxGravity(0.055f)
            )
        ),

        // OsseusFractus, OsseusCornibus, and OsseusPellebantus require galactic region support
        [Species.OsseusFractus] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.04f),
            new MaxGravity(0.276f),
            new MinTemperature(180.0f),
            new MaxTemperature(190.0f),
            new MinPressure(0.025f),
            new NoVolcanism(),
            new NotInRegion(GalacticRegion.Perseus)
        ),

        [Species.OsseusCornibus] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.0405f),
            new MaxGravity(0.276f),
            new MinTemperature(180.0f),
            new MaxTemperature(197.0f),
            new MinPressure(0.025f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.Perseus)
        ),

        [Species.OsseusPellebantus] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody, PlanetClass.HighMetalContentBody),
            new MinGravity(0.0405f),
            new MaxGravity(0.276f),
            new MinTemperature(191.0f),
            new MaxTemperature(197.0f),
            new MinPressure(0.057f),
            new NoVolcanism(),
            new NotInRegion(GalacticRegion.Perseus)
        ),

        // ============================================================================
        // RECEPTA (3 species) - Requires atmospheric composition support
        // ============================================================================

        [Species.ReceptaUmbrux] = new Special("Requires SulphurDioxide atmospheric composition > 1.05%"),
        [Species.ReceptaDeltahedronix] = new Special("Requires SulphurDioxide atmospheric composition > 1.05%"),
        [Species.ReceptaConditivus] = new Special("Requires SulphurDioxide atmospheric composition > 1.05%"),

        // ============================================================================
        // STRATUM (8 species)
        // ============================================================================

        [Species.StratumPaleas] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new MinGravity(0.04f),
                new MaxGravity(0.35f),
                new MinTemperature(165.0f),
                new MaxTemperature(177.0f),
                new MaxPressure(0.0135f),
                new RequiresPlanetClass(PlanetClass.RockyBody)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new MinGravity(0.04f),
                new MaxGravity(0.585f),
                new MinTemperature(165.0f),
                new MaxTemperature(395.0f),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxideRich),
                new MinGravity(0.43f),
                new MaxGravity(0.585f),
                new MinTemperature(185.0f),
                new MaxTemperature(260.0f),
                new MinPressure(0.015f),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new MinGravity(0.04f),
                new MaxGravity(0.056f),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new MinGravity(0.04f),
                new MaxGravity(0.056f),
                new MinPressure(0.065f),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new RequiresVolcanism(VolcanismType.WaterGeysers)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Oxygen),
                new MinGravity(0.39f),
                new MaxGravity(0.59f),
                new MinTemperature(165.0f),
                new MaxTemperature(250.0f),
                new MinPressure(0.022f),
                new RequiresPlanetClass(PlanetClass.RockyBody)
            )
        ),

        [Species.StratumAraneamus] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new MinGravity(0.26f),
                new MaxGravity(0.57f),
                new MinTemperature(165.0f),
                new MaxTemperature(373.0f),
                new RequiresPlanetClass(PlanetClass.RockyBody)
            )
        ),

        [Species.StratumTectonicas] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new MinGravity(0.045f),
                new MaxGravity(0.38f),
                new MinTemperature(165.0f),
                new MaxTemperature(177.0f),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Argon, AtmosphereType.ArgonRich),
                new MinGravity(0.485f),
                new MaxGravity(0.54f),
                new MinTemperature(167.0f),
                new MaxTemperature(199.0f),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody),
                new NoVolcanism()
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new MinGravity(0.045f),
                new MaxGravity(0.61f),
                new MinTemperature(165.0f),
                new MaxTemperature(430.0f),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxideRich),
                new MinGravity(0.035f),
                new MaxGravity(0.61f),
                new MinTemperature(165.0f),
                new MaxTemperature(260.0f),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Oxygen),
                new MinGravity(0.4f),
                new MaxGravity(0.52f),
                new MinTemperature(165.0f),
                new MaxTemperature(246.0f),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.SulphurDioxide),
                new MinGravity(0.29f),
                new MaxGravity(0.62f),
                new MinTemperature(165.0f),
                new MaxTemperature(450.0f),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.Water),
                new MinGravity(0.045f),
                new MaxGravity(0.063f),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody),
                new NoVolcanism()
            )
        ),

        // Other Stratum species require galactic region support
        // Stratum species have complex multi-ruleset conditions - using region filters as primary constraint
        [Species.StratumExcutitus] = new RequiresRegion(GalacticRegion.OrionCygnus),
        [Species.StratumLaminamus] = new RequiresRegion(GalacticRegion.OrionCygnus),
        [Species.StratumLimaxus] = new RequiresRegion(GalacticRegion.ScutumCentaurusCore),
        [Species.StratumCucumisis] = new RequiresRegion(GalacticRegion.SagittariusCarina),
        [Species.StratumFrigus] = new RequiresRegion(GalacticRegion.PerseusCore),

        // ============================================================================
        // TUBUS (5 species)
        // ============================================================================

        [Species.TubusSororibus] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody),
                new MinGravity(0.045f),
                new MaxGravity(0.152f),
                new MinTemperature(160.0f),
                new MaxTemperature(177.0f),
                new MaxPressure(0.0135f)
            ),
            new All(
                new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
                new RequiresPlanetClass(PlanetClass.HighMetalContentBody),
                new MinGravity(0.045f),
                new MaxGravity(0.152f),
                new MinTemperature(160.0f),
                new MaxTemperature(195.0f),
                new NoVolcanism()
            )
        ),

        [Species.TubusRosarium] = new Any(
            new All(
                new RequiresAtmosphere(AtmosphereType.Ammonia),
                new RequiresPlanetClass(PlanetClass.RockyBody),
                new MinGravity(0.04f),
                new MaxGravity(0.153f),
                new MinTemperature(160.0f),
                new MaxTemperature(177.0f),
                new MaxPressure(0.0135f)
            )
        ),

        // Other Tubus species require galactic region support
        [Species.TubusConifer] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody),
            new MinGravity(0.041f),
            new MaxGravity(0.153f),
            new MinTemperature(160.0f),
            new MaxTemperature(197.0f),
            new MinPressure(0.003f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.Perseus)
        ),

        [Species.TubusCavas] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody),
            new MinGravity(0.04f),
            new MaxGravity(0.152f),
            new MinTemperature(160.0f),
            new MaxTemperature(197.0f),
            new MinPressure(0.003f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.ScutumCentaurus)
        ),

        [Species.TubusCompagibus] = new All(
            new RequiresAtmosphere(AtmosphereType.CarbonDioxide),
            new RequiresPlanetClass(PlanetClass.RockyBody),
            new MinGravity(0.04f),
            new MaxGravity(0.153f),
            new MinTemperature(160.0f),
            new MaxTemperature(197.0f),
            new MinPressure(0.003f),
            new NoVolcanism(),
            new RequiresRegion(GalacticRegion.SagittariusCarina)
        ),

        // ============================================================================
        // Special species (TUBERS, BRAIN TREES, ANEMONES, SHARDS)
        // Require guardian site, tuber region, nebula, and other special conditions
        // ============================================================================

        // All Brain Trees require guardian sites and specific regions
        [Species.BrainTreeRoseum] = new Special("Requires guardian site and brain-tree region"),
        [Species.BrainTreeGypseeum] = new Special("Requires guardian site and brain-tree region"),
        [Species.BrainTreeOstrinum] = new Special("Requires guardian site and brain-tree region"),
        [Species.BrainTreeViride] = new Special("Requires guardian site and brain-tree region"),
        [Species.BrainTreeAureum] = new Special("Requires guardian site and brain-tree region"),
        [Species.BrainTreePuniceum] = new Special("Requires guardian site and brain-tree region"),
        [Species.BrainTreeLindigoticum] = new Special("Requires guardian site and brain-tree region"),
        [Species.BrainTreeLividum] = new Special("Requires guardian site and brain-tree region"),

        // All Anemones require specific star classes and galactic regions
        [Species.AnemoneLuteolum] = new Special("Requires specific star types and anemone region"),
        [Species.AnemoneCroceum] = new Special("Requires specific star types and anemone region"),
        [Species.AnemonePuniceum] = new Special("Requires O-class star and anemone region"),
        [Species.AnemoneRoseum] = new Special("Requires B-class star and anemone region"),
        [Species.AnemoneRubeumBioluminescent] = new Special("Requires specific star types"),
        [Species.AnemonePrasinumBioluminescent] = new Special("Requires O-class star"),
        [Species.AnemoneRoseumBioluminescent] = new Special("Requires B-class star"),
        [Species.AnemoneBlatteumBioluminescent] = new Special("Requires B-class star and anemone region"),

        // All Sinuous Tubers require specific tuber regions
        [Species.SinuousTubersRoseum] = new Special("Requires specific tuber region"),
        [Species.SinuousTubersPrasinum] = new Special("Requires specific tuber region"),
        [Species.SinuousTubersAlbidum] = new Special("Requires specific tuber region"),
        [Species.SinuousTubersCaeruleum] = new Special("Requires specific tuber region"),
        [Species.SinuousTubersLindigoticum] = new Special("Requires specific tuber region"),
        [Species.SinuousTubersViolaceum] = new Special("Requires specific tuber region"),
        [Species.SinuousTubersViride] = new Special("Requires specific tuber region"),
        [Species.SinuousTubersBlatteum] = new Special("Requires specific tuber region"),

        // Crystalline Shards
        // Crystalline Shards require distance > 12000 LS from arrival, system bodies, and exterior region
        // Note: Distance and system body checks still need implementation
        [Species.CrystallineShards] = new RequiresRegion(GalacticRegion.Exterior),

        // Bark Mounds and Amphora Plants
        [Species.BarkMound] = new Special("Requires nebula proximity"),
        [Species.AmphoraPlant] = new Special("Requires specific amphora region")
    };

    /// <summary>
    /// Gets all species that could potentially spawn on a given planet.
    /// </summary>
    public static List<Species> GetPossibleSpecies(PlanetContext context)
    {
        // All exobiology requires landing - non-landable bodies can't have species
        if (!context.IsLandable)
        {
            return new List<Species>();
        }

        var possible = new List<Species>();

        foreach (var kvp in Conditions)
        {
            if (kvp.Value.IsMet(context))
            {
                possible.Add(kvp.Key);
            }
        }

        return possible;
    }
}
