using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DockedInfo : EventBase
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

        internal static DockedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDockedEvent(JsonConvert.DeserializeObject<DockedInfo>(json, JsonSettings.Settings));
        }
    }
}