using System.Collections.Generic;
using System.Linq;

namespace EliteAPI.Exobiology.Models;

/// <summary>
/// Logical galactic regions used for species spawn conditions.
/// These map to one or more Elite Dangerous region IDs (1-42).
/// </summary>
public enum GalacticRegion
{
    // Major spiral arms and regions
    OrionCygnus,
    OrionCygnus1,
    OrionCygnusCore,
    SagittariusCarina,
    SagittariusCarineCore,
    SagittariusCarineCore9,
    ScutumCentaurus,
    ScutumCentaurusCore,
    Perseus,
    PerseusCore,
    Outer,
    Exterior,
    Center,

    // Special biological zones
    AnemoneA,
    Amphora,
    BrainTree,
    EmpyreanStraits,
}

/// <summary>
/// Maps logical galactic regions to Elite Dangerous region IDs (1-42).
/// Based on EDMC-BioScan region data.
/// </summary>
public static class GalacticRegionData
{
    /// <summary>
    /// Maps each logical region to the list of Elite Dangerous region IDs it covers.
    /// </summary>
    public static readonly Dictionary<GalacticRegion, List<int>> RegionMap = new()
    {
        [GalacticRegion.OrionCygnus] = new List<int> { 1, 4, 7, 8, 16, 17, 18, 35 },
        [GalacticRegion.OrionCygnus1] = new List<int> { 4, 7, 8, 16, 17, 18, 35 },
        [GalacticRegion.OrionCygnusCore] = new List<int> { 7, 8, 16, 17, 18, 35 },
        [GalacticRegion.SagittariusCarina] = new List<int> { 1, 4, 9, 18, 19, 20, 21, 22, 23, 40 },
        [GalacticRegion.SagittariusCarineCore] = new List<int> { 9, 18, 19, 20, 21, 22, 23, 40 },
        [GalacticRegion.SagittariusCarineCore9] = new List<int> { 18, 19, 20, 21, 22, 23, 40 },
        [GalacticRegion.ScutumCentaurus] = new List<int> { 1, 4, 9, 10, 11, 12, 24, 25, 26, 42, 28 },
        [GalacticRegion.ScutumCentaurusCore] = new List<int> { 9, 10, 11, 12, 24, 25, 26, 42, 28 },
        [GalacticRegion.Outer] = new List<int> { 1, 2, 5, 6, 13, 14, 27, 29, 31, 41, 37 },
        [GalacticRegion.Perseus] = new List<int> { 1, 3, 7, 15, 30, 32, 33, 34, 36, 38, 39 },
        [GalacticRegion.PerseusCore] = new List<int> { 3, 7, 15, 30, 32, 33, 34, 36, 38, 39 },
        [GalacticRegion.Exterior] = new List<int> { 14, 21, 22, 23, 24, 25, 26, 27, 28, 29, 31, 34, 36, 37, 38, 39, 40, 41, 42 },
        [GalacticRegion.AnemoneA] = new List<int> { 7, 8, 13, 14, 15, 16, 17, 18, 27, 32 },
        [GalacticRegion.Amphora] = new List<int> { 10, 19, 20, 21, 22 },
        [GalacticRegion.BrainTree] = new List<int> { 2, 9, 10, 17, 18, 35 },
        [GalacticRegion.EmpyreanStraits] = new List<int> { 2 },
        [GalacticRegion.Center] = new List<int> { 1, 2, 3 },
    };

    /// <summary>
    /// Checks if a region ID is within the specified logical region.
    /// </summary>
    public static bool IsInRegion(int? regionId, GalacticRegion region)
    {
        if (!regionId.HasValue) return false;
        return RegionMap[region].Contains(regionId.Value);
    }

    /// <summary>
    /// Checks if a region ID is within any of the specified logical regions.
    /// </summary>
    public static bool IsInAnyRegion(int? regionId, params GalacticRegion[] regions)
    {
        if (!regionId.HasValue) return false;
        return regions.Any(region => RegionMap[region].Contains(regionId.Value));
    }

    /// <summary>
    /// Checks if a region ID is NOT in the specified logical region.
    /// </summary>
    public static bool IsNotInRegion(int? regionId, GalacticRegion region)
    {
        if (!regionId.HasValue) return true; // If we don't know the region, we can't exclude it
        return !RegionMap[region].Contains(regionId.Value);
    }
}
