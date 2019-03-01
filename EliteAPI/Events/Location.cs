namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class LocationInfo
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Docked")]
        public bool Docked { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("StarPos")]
        public List<double> StarPos { get; internal set; }

        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; internal set; }

        [JsonProperty("SystemEconomy")]
        public string SystemEconomy { get; internal set; }

        [JsonProperty("SystemEconomy_Localised")]
        public string SystemEconomyLocalised { get; internal set; }

        [JsonProperty("SystemSecondEconomy")]
        public string SystemSecondEconomy { get; internal set; }

        [JsonProperty("SystemSecondEconomy_Localised")]
        public string SystemSecondEconomyLocalised { get; internal set; }

        [JsonProperty("SystemGovernment")]
        public string SystemGovernment { get; internal set; }

        [JsonProperty("SystemGovernment_Localised")]
        public string SystemGovernmentLocalised { get; internal set; }

        [JsonProperty("SystemSecurity")]
        public string SystemSecurity { get; internal set; }

        [JsonProperty("SystemSecurity_Localised")]
        public string SystemSecurityLocalised { get; internal set; }

        [JsonProperty("Population")]
        public long Population { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("BodyType")]
        public string BodyType { get; internal set; }

        [JsonProperty("Factions")]
        public List<Faction> Factions { get; internal set; }

        [JsonProperty("SystemFaction")]
        public SystemFaction SystemFaction { get; internal set; }
    }

    public partial class Faction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; internal set; }

        [JsonProperty("Government")]
        public string Government { get; internal set; }

        [JsonProperty("Influence")]
        public double Influence { get; internal set; }

        [JsonProperty("Allegiance")]
        public string Allegiance { get; internal set; }

        [JsonProperty("Happiness")]
        public string Happiness { get; internal set; }

        [JsonProperty("Happiness_Localised")]
        public string HappinessLocalised { get; internal set; }

        [JsonProperty("MyReputation")]
        public double MyReputation { get; internal set; }

        [JsonProperty("ActiveStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<ActiveState> ActiveStates { get; internal set; }
    }

    public partial class ActiveState
    {
        [JsonProperty("State")]
        public string State { get; internal set; }
    }

    public partial class SystemFaction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }

    public partial class LocationInfo
    {
        public static LocationInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLocationEvent(JsonConvert.DeserializeObject<LocationInfo>(json, EliteAPI.Events.LocationConverter.Settings));
    }

    public static class LocationSerializer
    {
        public static string ToJson(this LocationInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.LocationConverter.Settings);
    }

    internal static class LocationConverter
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
