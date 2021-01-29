using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class ScanEvent : EventBase
    {
        internal ScanEvent() { }

        [JsonProperty("ScanType")]
        public string ScanType { get; private set; }

        [JsonProperty("BodyName")]
        public string BodyName { get; private set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; private set; }

        [JsonProperty("Parents")]
        public IReadOnlyList<ParentInfo> Parents { get; private set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; private set; }

        [JsonProperty("DistanceFromArrivalLS")]
        public double DistanceFromArrivalLs { get; private set; }

        [JsonProperty("StarType")]
        public string StarType { get; private set; }

        [JsonProperty("Subclass")]
        public long Subclass { get; private set; }

        [JsonProperty("StellarMass")]
        public double StellarMass { get; private set; }

        [JsonProperty("Radius")]
        public double Radius { get; private set; }

        [JsonProperty("AbsoluteMagnitude")]
        public double AbsoluteMagnitude { get; private set; }

        [JsonProperty("Age_MY")]
        public long AgeMy { get; private set; }

        [JsonProperty("SurfaceTemperature")]
        public double SurfaceTemperature { get; private set; }

        [JsonProperty("Luminosity")]
        public string Luminosity { get; private set; }

        [JsonProperty("SemiMajorAxis")]
        public double SemiMajorAxis { get; private set; }

        [JsonProperty("Eccentricity")]
        public double Eccentricity { get; private set; }

        [JsonProperty("OrbitalInclination")]
        public double OrbitalInclination { get; private set; }

        [JsonProperty("Periapsis")]
        public double Periapsis { get; private set; }

        [JsonProperty("OrbitalPeriod")]
        public double OrbitalPeriod { get; private set; }

        [JsonProperty("RotationPeriod")]
        public double RotationPeriod { get; private set; }

        [JsonProperty("AxialTilt")]
        public double AxialTilt { get; private set; }

        [JsonProperty("Rings")]
        public IReadOnlyList<RingInfo> Rings { get; private set; }

        [JsonProperty("WasDiscovered")]
        public bool WasDiscovered { get; private set; }

        [JsonProperty("WasMapped")]
        public bool WasMapped { get; private set; }
        
        [JsonProperty("TidalLock")]
        public bool TidalLock { get; private set; }
        
        [JsonProperty("TerraformState")]
        public string TerraformState { get; private set; }
        
        [JsonProperty("PlanetState")]
        public string PlanetState { get; private set; }    
        
        [JsonProperty("PlanetClass")]
        public string PlanetClass { get; private set; }
        
        [JsonProperty("Atmosphere")]
        public string Atmosphere { get; private set; }
        
        [JsonProperty("AtmosphereType")]
        public string AtmosphereType { get; private set; }

        [JsonProperty("Volcanism")]
        public string Volcanism { get; private set; }
        
        [JsonProperty("MassEM")]
        public double MassEM { get; private set; }
        
        [JsonProperty("SurfaceGravity")]
        public double SurfaceGravity { get; private set; }
        
        [JsonProperty("SurfacePressure")]
        public double SurfacePressure { get; private set; }
        
        [JsonProperty("Landable")]
        public bool Landable { get; private set; }
        
        [JsonProperty("Materials")]
        public IReadOnlyList<Materialinfo> Materials { get; private set; }
        
        [JsonProperty("Composition")]
        public CompositionInfo Composition { get; private set; }
        
        [JsonProperty("AtmosphereComposition")]
        public IReadOnlyList<AtmosphereCompositionInfo> AtmosphereComposition { get; private set; }
        
        [JsonProperty("ReserveLevel")]
        public string ReserveLevel { get; private set; }
        
        public class ParentInfo
        {
            internal ParentInfo() { }

            [JsonProperty("Null")]
            public long Null { get; private set; }
        }

        public class RingInfo
        {
            internal RingInfo() { }

            [JsonProperty("Name")]
            public string Name { get; private set; }

            [JsonProperty("RingClass")]
            public string RingClass { get; private set; }

            [JsonProperty("MassMT")]
            public long MassMt { get; private set; }

            [JsonProperty("InnerRad")]
            public long InnerRad { get; private set; }

            [JsonProperty("OuterRad")]
            public long OuterRad { get; private set; }
        }
        
        public class Materialinfo
        {
            internal Materialinfo() { }

            [JsonProperty("Name")]
            public string Name { get; private set; }
            
            [JsonProperty("Percent")]
            public double Percent { get; private set; }
        }
        
        public class AtmosphereCompositionInfo
        {
            internal AtmosphereCompositionInfo() { }

            [JsonProperty("Name")]
            public string Name { get; private set; }
            
            [JsonProperty("Percent")]
            public double Percent { get; private set; }
        }
        
        public class CompositionInfo
        {
            internal CompositionInfo() { }

            [JsonProperty("Ice")]
            public double Ice { get; private set; }
            
            [JsonProperty("Rock")]
            public double Rock { get; private set; }
            
            [JsonProperty("Metal")]
            public double Metal { get; private set; }
        }

    }

    public partial class ScanEvent
    {
        public static ScanEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ScanEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ScanEvent> ScanEvent;

        internal void InvokeScanEvent(ScanEvent arg)
        {
            ScanEvent?.Invoke(this, arg);
        }
    }
}