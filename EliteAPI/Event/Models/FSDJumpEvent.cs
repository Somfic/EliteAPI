using System;
using System.Collections.Generic;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class FsdJumpEvent : EventBase
    {
        internal FsdJumpEvent()
        {
        }

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

        [JsonProperty("JumpDist")] public double JumpDist { get; private set; }

        [JsonProperty("FuelUsed")] public double FuelUsed { get; private set; }

        [JsonProperty("FuelLevel")] public double FuelLevel { get; private set; }

        [JsonProperty("FactionInfos")] public IReadOnlyList<FactionInfo> FactionInfos { get; private set; }

        [JsonProperty("SystemFaction")] public SystemFactionInfo SystemFaction { get; private set; }


        public class FactionInfo
        {
            internal FactionInfo()
            {
            }

            [JsonProperty("Name")] public string Name { get; private set; }

            [JsonProperty("FactionState")] public string FactionState { get; private set; }

            [JsonProperty("Government")] public string Government { get; private set; }

            [JsonProperty("Influence")] public double Influence { get; private set; }

            [JsonProperty("Allegiance")] public string Allegiance { get; private set; }

            [JsonProperty("Happiness")] public string Happiness { get; private set; }

            [JsonProperty("Happiness_Localised")] public string HappinessLocalised { get; private set; }

            [JsonProperty("MyReputation")] public double MyReputation { get; private set; }

            [JsonProperty("ActiveStateInfos", NullValueHandling = NullValueHandling.Ignore)]
            public IReadOnlyList<ActiveStateInfo> ActiveStateInfos { get; private set; }
        }

        public class ActiveStateInfo
        {
            internal ActiveStateInfo()
            {
            }

            [JsonProperty("State")] public string State { get; private set; }
        }

        public class SystemFactionInfo
        {
            internal SystemFactionInfo()
            {
            }

            [JsonProperty("Name")] public string Name { get; private set; }
        }
    }

    public partial class FsdJumpEvent
    {
        public static FsdJumpEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FsdJumpEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FsdJumpEvent> FsdJumpEvent;

        internal void InvokeFsdJumpEvent(FsdJumpEvent arg)
        {
            FsdJumpEvent?.Invoke(this, arg);
        }
    }
}