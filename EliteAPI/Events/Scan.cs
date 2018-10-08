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
            public int? Planet { get; set; }

            /// <summary>
            /// Whether the parent is a star.
            /// 0 = false, 1 = true
            /// </summary>
            public int? Star { get; set; }
        }

        public class MaterialInfo
        {
            public string Name { get; set; }
            public double Percent { get; set; }
        }

        public class CompositionInfo
        {
            public double Ice { get; set; }
            public double Rock { get; set; }
            public double Metal { get; set; }
        }

        public DateTime timestamp { get; set; }
        public string ScanType { get; set; }
        public string BodyName { get; set; }
        public int BodyID { get; set; }
        public List<ParentInfo> Parents { get; set; }
        public double DistanceFromArrivalLS { get; set; }
        public bool TidalLock { get; set; }
        public string TerraformState { get; set; }
        public string PlanetClass { get; set; }
        public string Atmosphere { get; set; }
        public string AtmosphereType { get; set; }
        public string Volcanism { get; set; }
        public double MassEM { get; set; }
        public double Radius { get; set; }
        public double SurfaceGravity { get; set; }
        public double SurfaceTemperature { get; set; }
        public double SurfacePressure { get; set; }
        public bool Landable { get; set; }
        public List<MaterialInfo> Materials { get; set; }
        public CompositionInfo Composition { get; set; }
        public double SemiMajorAxis { get; set; }
        public double Eccentricity { get; set; }
        public double OrbitalInclination { get; set; }
        public double Periapsis { get; set; }
        public double OrbitalPeriod { get; set; }
        public double RotationPeriod { get; set; }
        public double AxialTilt { get; set; }
    }
}