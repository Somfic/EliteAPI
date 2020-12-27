using System;
using System.Collections.Generic;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class DockedEvent : EventBase
    {
        internal DockedEvent()
        {
        }

        [JsonProperty("StationName")] public string StationName { get; private set; }

        [JsonProperty("StationAllegiance")] public string StationAllegiance { get; private set; }

        [JsonProperty("StationType")] public string StationType { get; private set; }

        [JsonProperty("StarSystem")] public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("StationFactionInfo")] public StationFactionInfo StationFaction { get; private set; }

        [JsonProperty("StationGovernment")] public string StationGovernment { get; private set; }

        [JsonProperty("StationGovernment_Localised")]
        public string StationGovernmentLocalised { get; private set; }

        [JsonProperty("StationServices")] public IReadOnlyList<string> StationServices { get; private set; }

        [JsonProperty("StationEconomyInfo")] public string StationEconomy { get; private set; }

        [JsonProperty("StationEconomyInfo_Localised")]
        public string StationEconomyInfoLocalised { get; private set; }

        [JsonProperty("StationEconomies")]
        public IReadOnlyList<StationEconomyInfo> StationEconomies { get; private set; }

        [JsonProperty("DistFromStarLS")] public double DistFromStarLs { get; private set; }


        public class StationEconomyInfo
        {
            internal StationEconomyInfo()
            {
            }

            [JsonProperty("Name")] public string Name { get; private set; }

            [JsonProperty("Name_Localised")] public string NameLocalised { get; private set; }

            [JsonProperty("Proportion")] public double Proportion { get; private set; }
        }

        public class StationFactionInfo
        {
            internal StationFactionInfo()
            {
            }

            [JsonProperty("Name")] public string Name { get; private set; }
        }
    }

    public partial class DockedEvent
    {
        public static DockedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DockedEvent>(json);
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