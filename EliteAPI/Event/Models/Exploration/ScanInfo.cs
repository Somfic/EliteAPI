using System.Collections.Generic;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Event.Models.Exploration
{
    public class ScanEvent : EventBase
    {
        internal ScanEvent() { }

        public static ScanEvent FromJson(string json) => JsonConvert.DeserializeObject<ScanEvent>(json);



        /// <summary>
        /// The type of scan.
        /// </summary>
        [JsonProperty("ScanType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ScanType ScanType { get; internal set; }

        /// <summary>
        /// The name of the system.
        /// </summary>
        /// <remarks>Only when the scan is of a star.</remarks>
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        /// <summary>
        /// The address of the system.
        /// </summary>
        /// <remarks>Only when the scan is of a star.</remarks>
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        /// <summary>
        /// The name of the body.
        /// </summary>
        [JsonProperty("BodyName")]
        public string BodyName { get; internal set; }

        /// <summary>
        /// The ID of the body.
        /// </summary>
        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        /// <summary>
        /// The distance from the arrival point in light-seconds.
        /// </summary>
        [JsonProperty("DistanceFromArrivalLS")]
        public float DistanceFromArrivalLs { get; internal set; }

        /// <summary>
        /// The type of the star.
        /// </summary>
        /// <remarks>Only when the scan is of a star.</remarks>
        [JsonProperty("StarType")]
        public string StarType { get; internal set; } //todo: turn this into an enum


        [JsonProperty("Parents")]
        public List<Parent> Parents { get; internal set; }

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
        public float MassEm { get; internal set; }

        [JsonProperty("Radius")]
        public float Radius { get; internal set; }

        [JsonProperty("SurfaceGravity")]
        public float SurfaceGravity { get; internal set; }

        [JsonProperty("SurfaceTemperature")]
        public float SurfaceTemperature { get; internal set; }

        [JsonProperty("SurfacePressure")]
        public float SurfacePressure { get; internal set; }

        [JsonProperty("Landable")]
        public bool Landable { get; internal set; }

        [JsonProperty("Materials")]
        public List<Material> Materials { get; internal set; }

        [JsonProperty("Composition")]
        public Composition Composition { get; internal set; }

        [JsonProperty("SemiMajorAxis")]
        public float SemiMajorAxis { get; internal set; }

        [JsonProperty("Eccentricity")]
        public float Eccentricity { get; internal set; }

        [JsonProperty("OrbitalInclination")]
        public float OrbitalInclination { get; internal set; }

        [JsonProperty("Periapsis")]
        public float Periapsis { get; internal set; }

        [JsonProperty("OrbitalPeriod")]
        public float OrbitalPeriod { get; internal set; }

        [JsonProperty("RotationPeriod")]
        public float RotationPeriod { get; internal set; }

        [JsonProperty("AxialTilt")]
        public float AxialTilt { get; internal set; }

        [JsonProperty("Rings")]
        public List<Ring> Rings { get; internal set; }

        [JsonProperty("ReserveLevel")]
        public string ReserveLevel { get; internal set; }

        
    }
}