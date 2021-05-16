using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class DockedEvent : EventBase<DockedEvent>
    {
        internal DockedEvent() { }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StationType")]
        public string StationType { get; private set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

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

        [JsonProperty("DistFromStarLS")]
        public double DistanceFromStarInLightSeconds { get; private set; }

        [JsonProperty("ActiveFine")]
        public bool HasActiveFine { get; private set; }

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

            [JsonProperty("FactionState", NullValueHandling = NullValueHandling.Ignore)]
            public string FactionState { get; private set; }
        }
    }


}

namespace EliteAPI.Event.Handler
{

    public partial class EventHandler
    {
        public event EventHandler<DockedEvent> DockedEvent;
        
        internal void InvokeDockedEvent(DockedEvent arg)
        {
            DockedEvent?.Invoke(this, arg);
        }
    }
}