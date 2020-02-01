using System;
using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class AddCommanderMission : IInaraEventData
    {
        public AddCommanderMission(string missionName, string missionGameID, string starSystemNameOrigin)
        {
            MissionName = missionName;
            MissionGameID = missionGameID;
            StarSystemNameOrigin = starSystemNameOrigin;
        }
        [JsonProperty("missionName")]
        public string MissionName { get; internal set; }
        [JsonProperty("missionGameID")]
        public string MissionGameID { get; internal set; }
        [JsonProperty("missionExpiry")]
        public DateTime MissionExpiry { get; internal set; }
        [JsonProperty("influenceGain")]
        public string InfluenceGain { get; internal set; }
        public GainType InfluenceGainAmount { get; internal set; }
        [JsonProperty("reputationGain")]
        public string ReputationGain { get; internal set; }
        public GainType ReputationGainAmount { get; internal set; }
        [JsonProperty("starSystemNameOrigin")]
        public string StarSystemNameOrigin { get; internal set; }
        [JsonProperty("stationNameOrigin")]
        public string StationNameOrigin { get; internal set; }
        [JsonProperty("minorFactionNameOrigin")]
        public string MinorFactionNameOrigin { get; internal set; }
        [JsonProperty("starSystemNameTarget")]
        public string StarsystemNameTarget { get; internal set; }
        [JsonProperty("stationNameTarget")]
        public string StationNameTarget { get; internal set; }
        [JsonProperty("minorFactionNameTarget")]
        public string MinorFactionNameTarget { get; internal set; }
        [JsonProperty("commodityName")]
        public string CommodityName { get; internal set; }
        [JsonProperty("commodityCount")]
        public long CommodityCount { get; internal set; }
        [JsonProperty("targetName")]
        public string TargetName { get; internal set; }
        [JsonProperty("targetType")]
        public string TargetType { get; internal set; }
        [JsonProperty("killCount")]
        public long KillCount { get; internal set; }
        [JsonProperty("passengerType")]
        public string PassengerType { get; internal set; }
        [JsonProperty("passengerCount")]
        public long PassengerCount { get; internal set; }
        [JsonProperty("passengerIsVIP")]
        public bool? PassengerIsVIP { get; internal set; }
        [JsonProperty("passengerIsWanted")]
        public bool? PassengerIsWanted { get; internal set; }
    }
    public enum GainType
    {
        Low,
        Med,
        High
    }
}
