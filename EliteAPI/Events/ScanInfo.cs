using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class ScanInfo : IEvent
    {
        internal static ScanInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeScanEvent(JsonConvert.DeserializeObject<ScanInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("ScanType")]
        public string ScanType { get; internal set; }
        [JsonProperty("BodyName")]
        public string BodyName { get; internal set; }
        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }
        [JsonProperty("Parents")]
        public List<Parent> Parents { get; internal set; }
        [JsonProperty("DistanceFromArrivalLS")]
        public double DistanceFromArrivalLs { get; internal set; }
        [JsonProperty("TidalLock")]
        public bool TidalLock { get; internal set; }
        [JsonProperty("TerraformState")]
        public string TerraformState { get; internal set; }
        [JsonProperty("PlanetClass")]
        public string PlanetClass { get; internal set; }
        [JsonProperty("Atmosphere")]
        public string Atmosphere { get; internal set; }
        [JsonProperty("AtmosphereType")]
        public string AtmosphereType { get; internal set; }
        [JsonProperty("Volcanism")]
        public string Volcanism { get; internal set; }
        [JsonProperty("MassEM")]
        public double MassEm { get; internal set; }
        [JsonProperty("Radius")]
        public double Radius { get; internal set; }
        [JsonProperty("SurfaceGravity")]
        public double SurfaceGravity { get; internal set; }
        [JsonProperty("SurfaceTemperature")]
        public double SurfaceTemperature { get; internal set; }
        [JsonProperty("SurfacePressure")]
        public double SurfacePressure { get; internal set; }
        [JsonProperty("Landable")]
        public bool Landable { get; internal set; }
        [JsonProperty("Materials")]
        public List<Material> Materials { get; internal set; }
        [JsonProperty("Composition")]
        public Composition Composition { get; internal set; }
        [JsonProperty("SemiMajorAxis")]
        public double SemiMajorAxis { get; internal set; }
        [JsonProperty("Eccentricity")]
        public double Eccentricity { get; internal set; }
        [JsonProperty("OrbitalInclination")]
        public double OrbitalInclination { get; internal set; }
        [JsonProperty("Periapsis")]
        public double Periapsis { get; internal set; }
        [JsonProperty("OrbitalPeriod")]
        public double OrbitalPeriod { get; internal set; }
        [JsonProperty("RotationPeriod")]
        public double RotationPeriod { get; internal set; }
        [JsonProperty("AxialTilt")]
        public double AxialTilt { get; internal set; }
        [JsonProperty("Rings")]
        public List<Ring> Rings { get; internal set; }
        [JsonProperty("ReserveLevel")]
        public string ReserveLevel { get; internal set; }
    }
}
