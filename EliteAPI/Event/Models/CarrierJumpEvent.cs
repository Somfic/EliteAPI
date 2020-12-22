using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class CarrierJumpEvent : EventBase
    {
        internal CarrierJumpEvent()
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

    public partial class CarrierJumpEvent
    {
        public static CarrierJumpEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CarrierJumpEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CarrierJumpEvent> CarrierJumpEvent;

        internal void InvokeCarrierJumpEvent(CarrierJumpEvent arg)
        {
            CarrierJumpEvent?.Invoke(this, arg);
        }
    }
}