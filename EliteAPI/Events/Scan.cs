namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ScanInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("ScanType")]
        public string ScanType { get; set; }

        [JsonProperty("BodyName")]
        public string BodyName { get; set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; set; }

        [JsonProperty("Parents")]
        public List<Parent> Parents { get; set; }

        [JsonProperty("DistanceFromArrivalLS")]
        public double DistanceFromArrivalLs { get; set; }

        [JsonProperty("TidalLock")]
        public bool TidalLock { get; set; }

        [JsonProperty("TerraformState")]
        public string TerraformState { get; set; }

        [JsonProperty("PlanetClass")]
        public string PlanetClass { get; set; }

        [JsonProperty("Atmosphere")]
        public string Atmosphere { get; set; }

        [JsonProperty("AtmosphereType")]
        public string AtmosphereType { get; set; }

        [JsonProperty("Volcanism")]
        public string Volcanism { get; set; }

        [JsonProperty("MassEM")]
        public double MassEm { get; set; }

        [JsonProperty("Radius")]
        public double Radius { get; set; }

        [JsonProperty("SurfaceGravity")]
        public double SurfaceGravity { get; set; }

        [JsonProperty("SurfaceTemperature")]
        public double SurfaceTemperature { get; set; }

        [JsonProperty("SurfacePressure")]
        public double SurfacePressure { get; set; }

        [JsonProperty("Landable")]
        public bool Landable { get; set; }

        [JsonProperty("Materials")]
        public List<Material> Materials { get; set; }

        [JsonProperty("Composition")]
        public Composition Composition { get; set; }

        [JsonProperty("SemiMajorAxis")]
        public double SemiMajorAxis { get; set; }

        [JsonProperty("Eccentricity")]
        public double Eccentricity { get; set; }

        [JsonProperty("OrbitalInclination")]
        public double OrbitalInclination { get; set; }

        [JsonProperty("Periapsis")]
        public double Periapsis { get; set; }

        [JsonProperty("OrbitalPeriod")]
        public double OrbitalPeriod { get; set; }

        [JsonProperty("RotationPeriod")]
        public double RotationPeriod { get; set; }

        [JsonProperty("AxialTilt")]
        public double AxialTilt { get; set; }

        [JsonProperty("Rings")]
        public List<Ring> Rings { get; set; }

        [JsonProperty("ReserveLevel")]
        public string ReserveLevel { get; set; }
    }

    public partial class Composition
    {
        [JsonProperty("Ice")]
        public double Ice { get; set; }

        [JsonProperty("Rock")]
        public double Rock { get; set; }

        [JsonProperty("Metal")]
        public double Metal { get; set; }
    }

    public partial class Material
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; set; }

        [JsonProperty("Percent")]
        public double Percent { get; set; }
    }

    public partial class Parent
    {
        [JsonProperty("Null")]
        public long Null { get; set; }
    }

    public partial class Ring
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("RingClass")]
        public string RingClass { get; set; }

        [JsonProperty("MassMT")]
        public double MassMt { get; set; }

        [JsonProperty("InnerRad")]
        public double InnerRad { get; set; }

        [JsonProperty("OuterRad")]
        public double OuterRad { get; set; }
    }

    public partial class ScanInfo
    {
        public static ScanInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeScanEvent(JsonConvert.DeserializeObject<ScanInfo>(json, EliteAPI.Events.ScanConverter.Settings));
    }

    public static class ScanSerializer
    {
        public static string ToJson(this ScanInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ScanConverter.Settings);
    }

    internal static class ScanConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
