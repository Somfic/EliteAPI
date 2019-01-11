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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StationType")]
        public string StationType { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("StationFaction")]
        public string StationFaction { get; set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; set; }

        [JsonProperty("StationGovernment")]
        public string StationGovernment { get; set; }

        [JsonProperty("StationGovernment_Localised")]
        public string StationGovernmentLocalised { get; set; }

        [JsonProperty("StationAllegiance")]
        public string StationAllegiance { get; set; }

        [JsonProperty("StationServices")]
        public List<string> StationServices { get; set; }

        [JsonProperty("StationEconomy")]
        public string StationEconomy { get; set; }

        [JsonProperty("StationEconomy_Localised")]
        public string StationEconomyLocalised { get; set; }

        [JsonProperty("StationEconomies")]
        public List<StationEconomy> StationEconomies { get; set; }

        [JsonProperty("DistFromStarLS")]
        public double DistFromStarLs { get; set; }
    }

    public partial class StationEconomy
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; set; }

        [JsonProperty("Proportion")]
        public double Proportion { get; set; }
    }

    public partial class DockedInfo
    {
        public static DockedInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeDockedEvent(JsonConvert.DeserializeObject<DockedInfo>(json, EliteAPI.Events.DockedConverter.Settings));
    }

    public static class DockedSerializer
    {
        public static string ToJson(this DockedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DockedConverter.Settings);
    }

    internal static class DockedConverter
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
