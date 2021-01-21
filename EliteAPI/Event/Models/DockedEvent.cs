
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class DockedEvent : EventBase
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
        public double DistFromStarLs { get; private set; }
    

    public partial class StationEconomyInfo
    {
        internal StationEconomyInfo() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; private set; }

        [JsonProperty("Proportion")]
        public double Proportion { get; private set; }
    }

    public partial class StationFactionInfo
    {
        internal StationFactionInfo() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; private set; }
    }

}

    public partial class DockedEvent
    {
        public static DockedEvent FromJson(string json) => JsonConvert.DeserializeObject<DockedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<DockedEvent> DockedEvent;
        internal void InvokeDockedEvent(DockedEvent arg) => DockedEvent?.Invoke(this, arg);
    }
}
