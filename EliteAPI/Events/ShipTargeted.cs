namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ShipTargetedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("TargetLocked")]
        public bool TargetLocked { get; set; }

        [JsonProperty("Ship")]
        public string Ship { get; set; }

        [JsonProperty("Ship_Localised")]
        public string ShipLocalised { get; set; }

        [JsonProperty("ScanStage")]
        public long ScanStage { get; set; }

        [JsonProperty("PilotName")]
        public string PilotName { get; set; }

        [JsonProperty("PilotName_Localised")]
        public string PilotNameLocalised { get; set; }

        [JsonProperty("PilotRank")]
        public string PilotRank { get; set; }

        [JsonProperty("ShieldHealth")]
        public double ShieldHealth { get; set; }

        [JsonProperty("HullHealth")]
        public double HullHealth { get; set; }

        [JsonProperty("Faction")]
        public string Faction { get; set; }

        [JsonProperty("LegalStatus")]
        public string LegalStatus { get; set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; set; }

        [JsonProperty("Subsystem")]
        public string Subsystem { get; set; }

        [JsonProperty("Subsystem_Localised")]
        public string SubsystemLocalised { get; set; }

        [JsonProperty("SubsystemHealth")]
        public double SubsystemHealth { get; set; }
    }

    public partial class ShipTargetedInfo
    {
        public static ShipTargetedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShipTargetedEvent(JsonConvert.DeserializeObject<ShipTargetedInfo>(json, EliteAPI.Events.ShipTargetedConverter.Settings));
    }

    public static class ShipTargetedSerializer
    {
        public static string ToJson(this ShipTargetedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ShipTargetedConverter.Settings);
    }

    internal static class ShipTargetedConverter
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
