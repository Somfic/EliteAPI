using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class ScanInfo
    {
        public class ParentInfo
        {
            /// <summary>
            /// Whether the parent is a planet.
            /// 0 = false, 1 = true
            /// </summary>
            public int? Planet { get; }

            /// <summary>
            /// Whether the parent is a star.
            /// 0 = false, 1 = true
            /// </summary>
            public int? Star { get; }
        }

        public class MaterialInfo
        {
            public string Name { get; }
            public double Percent { get; }
        }

        public class CompositionInfo
        {
            public double Ice { get; }
            public double Rock { get; }
            public double Metal { get; }
        }

        public DateTime timestamp { get; }
        public string ScanType { get; }
        public string BodyName { get; }
        public int BodyID { get; }
        public List<ParentInfo> Parents { get; }
        public double DistanceFromArrivalLS { get; }
        public bool TidalLock { get; }
        public string TerraformState { get; }
        public string PlanetClass { get; }
        public string Atmosphere { get; }
        public string AtmosphereType { get; }
        public string Volcanism { get; }
        public double MassEM { get; }
        public double Radius { get; }
        public double SurfaceGravity { get; }
        public double SurfaceTemperature { get; }
        public double SurfacePressure { get; }
        public bool Landable { get; }
        public List<MaterialInfo> Materials { get; }
        public CompositionInfo Composition { get; }
        public double SemiMajorAxis { get; }
        public double Eccentricity { get; }
        public double OrbitalInclination { get; }
        public double Periapsis { get; }
        public double OrbitalPeriod { get; }
        public double RotationPeriod { get; }
        public double AxialTilt { get; }
    }
}