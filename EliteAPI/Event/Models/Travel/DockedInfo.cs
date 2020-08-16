using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Event.Models.Travel
{
    /// <summary>
    /// This event is written when landed at a landing pad in a station, output or surface settlement.
    /// </summary>
    public class DockedEvent : EventBase
    {
        internal DockedEvent() { }

        public static DockedEvent FromJson(string json) => JsonConvert.DeserializeObject<DockedEvent>(json);



        /// <summary>
        /// The name of the station.
        /// </summary>
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        /// <summary>
        /// The ID of the station market.
        /// </summary>
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        /// <summary>
        /// The address of the system.
        /// </summary>
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

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
        /// Whether the cockpit is breached upon docking.
        /// </summary>
        [JsonProperty("CockpitBreach")]
        public bool CockpitBreach { get; internal set; }

        /// <summary>
        /// Whether the commander is landed upon docking.
        /// </summary>
        [JsonProperty("Wanted")]
        public bool Wanted { get; internal set; }

        /// <summary>
        /// Whether the commander has an active fine upon docking.
        /// </summary>
        [JsonProperty("ActiveFine")]
        public bool ActiveFine { get; internal set; }

        /// <summary>
        /// Holds information on the station's main faction.
        /// </summary>
        /// <see cref="StationFaction"/>
        [JsonProperty("StationFaction")]
        public DockedStationFaction StationFaction { get; internal set; }

        /// <summary>
        /// The station's allegiance.
        /// </summary>
        [JsonProperty("StationAllegiance")]
        public string StationAllegiance { get; internal set; }

        /// <summary>
        /// The station's primary economy.
        /// </summary>
        [JsonProperty("StationEconomy")]
        public string StationEconomy { get; internal set; } //todo: turn this into an enum

        /// <summary>
        /// The station's primary economy localised.
        /// </summary>
        [JsonProperty("StationEconomy_Localised")]
        public string StationEconomyLocalised { get; internal set; }

        /// <summary>
        /// A list of station economies.
        /// </summary>
        [JsonProperty("StationEconomies")]
        public IReadOnlyList<DockedStationEconomy> StationEconomies { get; internal set; }

        /// <summary>
        /// The station's government.
        /// </summary>
        [JsonProperty("StationGovernment")]
        public string StationGovernment { get; internal set; } //todo: turn this into an enum

        /// <summary>
        /// The station's government localised.
        /// </summary>
        [JsonProperty("StationGovernment_Localised")]
        public string StationGovernmentLocalised { get; internal set; }

        /// <summary>
        /// A list of services this station has.
        /// </summary>
        [JsonProperty("StationServices")]
        public IReadOnlyList<string> StationServices { get; internal set; } //todo: turn this into an enum

        /// <summary>
        /// Whether the commander has limited access to the station services.
        /// </summary>
        public bool Anonymously => Wanted | ActiveFine;

        /// <summary>
        /// This station's distance from the primary star in this starsystem.
        /// </summary>
        [JsonProperty("DistFromStarLS")]
        public float DistFromStarLs { get; internal set; }

        
    }
}