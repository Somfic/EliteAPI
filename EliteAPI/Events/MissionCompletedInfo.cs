using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class MissionCompletedInfo : EventBase
    {
        internal static MissionCompletedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionCompletedEvent(JsonConvert.DeserializeObject<MissionCompletedInfo>(json, JsonSettings.Settings));

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }
        [JsonProperty("TargetType")]
        public string TargetType { get; internal set; }
        [JsonProperty("TargetType_Localised")]
        public string TargetTypeLocalised { get; internal set; }
        [JsonProperty("TargetFaction")]
        public string TargetFaction { get; internal set; }
        [JsonProperty("NewDestinationSystem")]
        public string NewDestinationSystem { get; internal set; }
        [JsonProperty("DestinationSystem")]
        public string DestinationSystem { get; internal set; }
        [JsonProperty("NewDestinationStation")]
        public string NewDestinationStation { get; internal set; }
        [JsonProperty("DestinationStation")]
        public string DestinationStation { get; internal set; }
        [JsonProperty("Target")]
        public string Target { get; internal set; }
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }
        [JsonProperty("MaterialsReward")]
        public List<MaterialsReward> MaterialsReward { get; internal set; }
        [JsonProperty("FactionEffects")]
        public List<FactionEffect> FactionEffects { get; internal set; }
    }
}
