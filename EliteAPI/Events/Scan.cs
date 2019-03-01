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

    public partial class Composition
    {
        [JsonProperty("Ice")]
        public double Ice { get; internal set; }

        [JsonProperty("Rock")]
        public double Rock { get; internal set; }

        [JsonProperty("Metal")]
        public double Metal { get; internal set; }
    }

    public partial class Material
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Percent")]
        public double Percent { get; internal set; }
    }

    public partial class Parent
    {
        [JsonProperty("Null")]
        public long Null { get; internal set; }
    }

    public partial class Ring
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("RingClass")]
        public string RingClass { get; internal set; }

        [JsonProperty("MassMT")]
        public double MassMt { get; internal set; }

        [JsonProperty("InnerRad")]
        public double InnerRad { get; internal set; }

        [JsonProperty("OuterRad")]
        public double OuterRad { get; internal set; }
    }

    public partial class ScanInfo
    {
        public static ScanInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeScanEvent(JsonConvert.DeserializeObject<ScanInfo>(json, EliteAPI.Events.ScanConverter.Settings));
    }

    public static class ScanSerializer
    {
        public static string ToJson(this ScanInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ScanConverter.Settings);
    }

    internal static class ScanConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
