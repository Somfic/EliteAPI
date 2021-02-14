using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class LocationEvent : EventBase<LocationEvent>
    {
        internal LocationEvent() { }

        [JsonProperty("Longitude")]
        public double Longitude { get; private set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; private set; }

        [JsonProperty("Docked")]
        public bool Docked { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StationType")]
        public string StationType { get; private set; }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }

        [JsonProperty("StationFaction")]
        public StationFactionInfo StationFaction { get; private set; }

        [JsonProperty("StationGovernment")]
        public string StationGovernment { get; private set; }

        [JsonProperty("StationGovernment_Localised")]
        public string StationGovernmentLocalised { get; private set; }

        [JsonProperty("StationAllegiance")]
        public string StationAllegiance { get; private set; }

        [JsonProperty("StationServices")]
        public IReadOnlyList<string> StationServices { get; private set; }

        [JsonProperty("StationEconomy")]
        public string StationEconomy { get; private set; }

        [JsonProperty("StationEconomy_Localised")]
        public string StationEconomyLocalised { get; private set; }

        [JsonProperty("StationEconomies")]
        public IReadOnlyList<StationEconomyInfo> StationEconomies { get; private set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

        [JsonProperty("StarPos")]
        public IReadOnlyList<double> StarPos { get; private set; }

        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; private set; }

        [JsonProperty("SystemEconomy")]
        public string SystemEconomy { get; private set; }

        [JsonProperty("SystemEconomy_Localised")]
        public string SystemEconomyLocalised { get; private set; }

        [JsonProperty("SystemSecondEconomy")]
        public string SystemSecondEconomy { get; private set; }

        [JsonProperty("SystemSecondEconomy_Localised")]
        public string SystemSecondEconomyLocalised { get; private set; }

        [JsonProperty("SystemGovernment")]
        public string SystemGovernment { get; private set; }

        [JsonProperty("SystemGovernment_Localised")]
        public string SystemGovernmentLocalised { get; private set; }

        [JsonProperty("SystemSecurity")]
        public string SystemSecurity { get; private set; }

        [JsonProperty("SystemSecurity_Localised")]
        public string SystemSecurityLocalised { get; private set; }

        [JsonProperty("Population")]
        public long Population { get; private set; }

        [JsonProperty("Body")]
        public string Body { get; private set; }

        [JsonProperty("BodyID")]
        public string BodyId { get; private set; }

        [JsonProperty("BodyType")]
        public string BodyType { get; private set; }

        [JsonProperty("Powers")]
        public IReadOnlyList<string> Powers { get; private set; }

        [JsonProperty("PowerplayState")]
        public string PowerplayState { get; private set; }

        [JsonProperty("Factions")]
        public IReadOnlyList<FactionInfo> Factions { get; private set; }

        [JsonProperty("SystemFaction")]
        public StationFactionInfo SystemFaction { get; private set; }

        [JsonProperty("Conflicts")]
        public IReadOnlyList<ConflictInfo> Conflicts { get; private set; }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class FactionInfo
        {
            internal FactionInfo() { }

            [JsonProperty("Name")]
            public string Name { get; private set; }

            [JsonProperty("FactionState")]
            public string FactionState { get; private set; }

            [JsonProperty("Government")]
            public string Government { get; private set; }

            [JsonProperty("Influence")]
            public double Influence { get; private set; }

            [JsonProperty("Allegiance")]
            public string Allegiance { get; private set; }

            [JsonProperty("Happiness")]
            public string Happiness { get; private set; }

            [JsonProperty("Happiness_Localised")]
            public string HappinessLocalised { get; private set; }

            [JsonProperty("MyReputation")]
            public double MyReputation { get; private set; }

            [JsonProperty("ActiveStates", NullValueHandling = NullValueHandling.Ignore)]
            public IReadOnlyList<ActiveStateInfo> ActiveStates { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class ActiveStateInfo
        {
            internal ActiveStateInfo() { }

            [JsonProperty("State")]
            public string State { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class StationEconomyInfo
        {
            internal StationEconomyInfo() { }

            [JsonProperty("Name")]
            public string Name { get; private set; }

            [JsonProperty("Name_Localised")]
            public string NameLocalised { get; private set; }

            [JsonProperty("Proportion")]
            public double Proportion { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class StationFactionInfo
        {
            internal StationFactionInfo() { }

            [JsonProperty("Name")]
            public string Name { get; private set; }

            [JsonProperty("FactionState")]
            public string FactionState { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class ConflictInfo
        {
            [JsonProperty("WarType")]
            public string WarType { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }

            [JsonProperty("Faction1")]
            public ConflictFactionInfo Faction1 { get; set; }

            [JsonProperty("Faction2")]
            public ConflictFactionInfo Faction2 { get; set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class ConflictFactionInfo
        {
            internal ConflictFactionInfo() { }

            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("Stake")]
            public string Stake { get; set; }

            [JsonProperty("WonDays")]
            public long WonDays { get; set; }
        }
    }


}

namespace EliteAPI.Event.Handler
{

    public partial class EventHandler
    {
        public event EventHandler<LocationEvent> LocationEvent;
        
        internal void InvokeLocationEvent(LocationEvent arg)
        {
            LocationEvent?.Invoke(this, arg);
        }
    }
}