using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Events.Travel
{
    /// <summary>
    /// This event is written when landed at a landing pad in a station, output or surface settlement.
    /// </summary>
    public class DockedInfo : EventBase
    {
        internal DockedInfo() { }

        /// <summary>
        /// The name of the station.
        /// </summary>
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        /// <summary>
        /// The type of station.
        /// </summary>
        [JsonProperty("StationType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StationType StationType { get; internal set; }

        /// <summary>
        /// The starsystem of the station.
        /// </summary>
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        /// <summary>
        /// The address of the system.
        /// </summary>
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        /// <summary>
        /// The ID of the station market.
        /// </summary>
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        /// <summary>
        /// Holds information on the station's main faction.
        /// </summary>
        /// <see cref="StationFaction"/>
        [JsonProperty("StationFaction")]
        public DockedStationFaction StationFaction { get; internal set; }

        [JsonProperty("StationGovernment")]
        public string StationGovernment { get; internal set; }

        [JsonProperty("StationGovernment_Localised")]
        public string StationGovernmentLocalised { get; internal set; }

        [JsonProperty("StationAllegiance")]
        public string StationAllegiance { get; internal set; }

        [JsonProperty("StationServices")]
        public IReadOnlyList<string> StationServices { get; internal set; }

        [JsonProperty("StationEconomy")]
        public string StationEconomy { get; internal set; }

        [JsonProperty("StationEconomy_Localised")]
        public string StationEconomyLocalised { get; internal set; }    

        [JsonProperty("StationEconomies")]
        public IReadOnlyList<DockedStationEconomy> StationEconomies { get; internal set; }

        [JsonProperty("DistFromStarLS")]
        public float DistFromStarLs { get; internal set; }

        internal static DockedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDockedEvent(JsonConvert.DeserializeObject<DockedInfo>(json, JsonSettings.Settings));
        }
    }
}