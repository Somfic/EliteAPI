using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class LocationEvent : EventBase
    {
        internal LocationEvent()
        {
        }

        [JsonProperty("Docked")] public bool Docked { get; private set; }

        [JsonProperty("StationName")] public string StationName { get; private set; }

        [JsonProperty("StationType")] public string StationType { get; private set; }

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

        [JsonProperty("StarSystem")] public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("StarPos")] public IReadOnlyList<double> StarPos { get; private set; }

        [JsonProperty("SystemAllegiance")] public string SystemAllegiance { get; private set; }

        [JsonProperty("SystemEconomy")] public string SystemEconomy { get; private set; }

        [JsonProperty("SystemEconomy_Localised")]
        public string SystemEconomyLocalised { get; private set; }

        [JsonProperty("SystemSecondEconomy")] public string SystemSecondEconomy { get; private set; }

        [JsonProperty("SystemSecondEconomy_Localised")]
        public string SystemSecondEconomyLocalised { get; private set; }

        [JsonProperty("SystemGovernment")] public string SystemGovernment { get; private set; }

        [JsonProperty("SystemGovernment_Localised")]
        public string SystemGovernmentLocalised { get; private set; }

        [JsonProperty("SystemSecurity")] public string SystemSecurity { get; private set; }

        [JsonProperty("SystemSecurity_Localised")]
        public string SystemSecurityLocalised { get; private set; }

        [JsonProperty("Population")] public long Population { get; private set; }

        [JsonProperty("Body")] public string Body { get; private set; }

        [JsonProperty("BodyID")] public long BodyId { get; private set; }

        [JsonProperty("BodyType")] public string BodyType { get; private set; }

        [JsonProperty("Powers")] public IReadOnlyList<string> Powers { get; private set; }

        [JsonProperty("PowerplayState")] public string PowerplayState { get; private set; }

        [JsonProperty("FactionInfos")] public IReadOnlyList<FactionInfoElement> FactionInfos { get; private set; }

        [JsonProperty("SystemFactionInfo")] public StationFactionInfo SystemFaction { get; private set; }

        [JsonProperty("ConflictInfos")] public IReadOnlyList<ConflictInfo> ConflictInfos { get; private set; }


        public class ConflictInfo
        {
            internal ConflictInfo()
            {
            }

            [JsonProperty("WarType")] public string WarType { get; private set; }

            [JsonProperty("Status")] public string Status { get; private set; }

            [JsonProperty("FactionInfo1")] public FactionInfo FactionInfo1 { get; private set; }

            [JsonProperty("FactionInfo2")] public FactionInfo FactionInfo2 { get; private set; }
        }

        public class FactionInfo
        {
            internal FactionInfo()
            {
            }

            [JsonProperty("Name")] public string Name { get; private set; }

            [JsonProperty("Stake")] public string Stake { get; private set; }

            [JsonProperty("WonDays")] public long WonDays { get; private set; }
        }

        public class FactionInfoElement
        {
            internal FactionInfoElement()
            {
            }

            [JsonProperty("Name")] public string Name { get; private set; }

            [JsonProperty("FactionInfoState")] public string FactionInfoState { get; private set; }

            [JsonProperty("Government")] public string Government { get; private set; }

            [JsonProperty("Influence")] public double Influence { get; private set; }

            [JsonProperty("Allegiance")] public string Allegiance { get; private set; }

            [JsonProperty("Happiness")] public string Happiness { get; private set; }

            [JsonProperty("Happiness_Localised")] public string HappinessLocalised { get; private set; }

            [JsonProperty("MyReputation")] public double MyReputation { get; private set; }

            [JsonProperty("PendingStateInfos", NullValueHandling = NullValueHandling.Ignore)]
            public IReadOnlyList<PendingStateInfo> PendingStateInfos { get; private set; }

            [JsonProperty("ActiveStateInfos", NullValueHandling = NullValueHandling.Ignore)]
            public IReadOnlyList<ActiveStateInfo> ActiveStateInfos { get; private set; }

            [JsonProperty("RecoveringStateInfos", NullValueHandling = NullValueHandling.Ignore)]
            public IReadOnlyList<RecoveringStateInfo> RecoveringStateInfos { get; private set; }
        }

        public class ActiveStateInfo
        {
            internal ActiveStateInfo()
            {
            }

            [JsonProperty("State")] public string State { get; private set; }
        }

        public class RecoveringStateInfo
        {
            internal RecoveringStateInfo()
            {
            }

            [JsonProperty("State")] public string State { get; private set; }

            [JsonProperty("Trend")] public long Trend { get; private set; }
        }

        public class PendingStateInfo
        {
            internal PendingStateInfo()
            {
            }

            [JsonProperty("State")] public string State { get; private set; }

            [JsonProperty("Trend")] public long Trend { get; private set; }
        }

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

    public partial class LocationEvent
    {
        public static LocationEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LocationEvent>(json);
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