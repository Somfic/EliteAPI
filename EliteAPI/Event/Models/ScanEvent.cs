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
        public IReadOnlyList<Parent> Parents { get; private set; }

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

        [JsonProperty("WasDiscovered")]
        public bool WasDiscovered { get; private set; }

        [JsonProperty("WasMapped")]
        public bool WasMapped { get; private set; }
    }

    public class Parent
    {
        internal Parent() { }

        [JsonProperty("Null")]
        public long Null { get; private set; }
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