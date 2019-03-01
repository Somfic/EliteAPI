namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DockedInfo
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationFaction")]
        public StationFaction StationFaction { get; internal set; }

        [JsonProperty("StationGovernment")]
        public string StationGovernment { get; internal set; }

        [JsonProperty("StationGovernment_Localised")]
        public string StationGovernmentLocalised { get; internal set; }

        [JsonProperty("StationAllegiance")]
        public string StationAllegiance { get; internal set; }

        [JsonProperty("StationServices")]
        public List<string> StationServices { get; internal set; }

        [JsonProperty("StationEconomy")]
        public string StationEconomy { get; internal set; }

        [JsonProperty("StationEconomy_Localised")]
        public string StationEconomyLocalised { get; internal set; }

        [JsonProperty("StationEconomies")]
        public List<StationEconomy> StationEconomies { get; internal set; }

        [JsonProperty("DistFromStarLS")]
        public double DistFromStarLs { get; internal set; }
    }

    public partial class StationEconomy
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Proportion")]
        public double Proportion { get; internal set; }
    }

    public partial class StationFaction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }

    public partial class DockedInfo
    {
        public static DockedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockedEvent(JsonConvert.DeserializeObject<DockedInfo>(json, EliteAPI.Events.DockedConverter.Settings));
    }

    public static class DockedSerializer
    {
        public static string ToJson(this DockedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DockedConverter.Settings);
    }

    internal static class DockedConverter
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
