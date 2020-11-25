
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class MissionCompletedEvent : EventBase
    {
        internal MissionCompletedEvent() { }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; private set; }

        [JsonProperty("TargetType")]
        public string TargetType { get; private set; }

        [JsonProperty("TargetType_Localised")]
        public string TargetTypeLocalised { get; private set; }

        [JsonProperty("TargetFaction")]
        public string TargetFaction { get; private set; }

        [JsonProperty("NewDestinationSystem")]
        public string NewDestinationSystem { get; private set; }

        [JsonProperty("DestinationSystem")]
        public string DestinationSystem { get; private set; }

        [JsonProperty("NewDestinationStation")]
        public string NewDestinationStation { get; private set; }

        [JsonProperty("DestinationStation")]
        public string DestinationStation { get; private set; }

        [JsonProperty("Target")]
        public string Target { get; private set; }

        [JsonProperty("Reward")]
        public long Reward { get; private set; }

        [JsonProperty("FactionEffectInfos")]
        public IReadOnlyList<FactionEffectInfo> FactionEffectInfos { get; private set; }
    

    public partial class FactionEffectInfo
    {
        internal FactionEffectInfo() { }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }

        [JsonProperty("EffectInfos")]
        public IReadOnlyList<EffectInfo> EffectInfos { get; private set; }

        [JsonProperty("InfluenceInfo")]
        public IReadOnlyList<InfluenceInfo> Influence { get; private set; }

        [JsonProperty("ReputationTrend")]
        public string ReputationTrend { get; private set; }

        [JsonProperty("Reputation")]
        public string Reputation { get; private set; }
    }

    public partial class EffectInfo
    {
        internal EffectInfo() { }

        [JsonProperty("EffectInfo")]
        public string EffectInfoEffect { get; private set; }

        [JsonProperty("EffectInfo_Localised")]
        public string EffectInfoLocalised { get; private set; }

        [JsonProperty("Trend")]
        public string Trend { get; private set; }
    }

    public partial class InfluenceInfo
    {
        internal InfluenceInfo() { }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; private set; }

        [JsonProperty("Trend")]
        public string Trend { get; private set; }

        [JsonProperty("InfluenceInfo")]
        public string InfluenceInfoInfluence { get; private set; }
    }

}

    public partial class MissionCompletedEvent
    {
        public static MissionCompletedEvent FromJson(string json) => JsonConvert.DeserializeObject<MissionCompletedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<MissionCompletedEvent> MissionCompletedEvent;
        internal void InvokeMissionCompletedEvent(MissionCompletedEvent arg) => MissionCompletedEvent?.Invoke(this, arg);
    }
}
