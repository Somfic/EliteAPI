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
        public string MissionName { get; set; }
        [JsonProperty("missionGameID")]
        public string MissionGameID { get; set; }
        [JsonProperty("missionExpiry")]
        public DateTime MissionExpiry { get; set; }
        [JsonProperty("influenceGain")]
        public string InfluenceGain { get => InfluenceGain.ToString(); }
        public GainType InfluenceGainAmount { get; set; }
        [JsonProperty("reputationGain")]
        public string ReputationGain { get => ReputationGain.ToString(); }
        public GainType ReputationGainAmount { get; set; }
        [JsonProperty("starSystemNameOrigin")]
        public string StarSystemNameOrigin { get; set; }
        [JsonProperty("stationNameOrigin")]
        public string StationNameOrigin { get; set; }
        [JsonProperty("minorFactionNameOrigin")]
        public string MinorFactionNameOrigin { get; set; }
        [JsonProperty("starSystemNameTarget")]
        public string StarsystemNameTarget { get; set; }
        [JsonProperty("stationNameTarget")]
        public string StationNameTarget { get; set; }
        [JsonProperty("minorFactionNameTarget")]
        public string MinorFactionNameTarget { get; set; }
        [JsonProperty("commodityName")]
        public string CommodityName { get; set; }
        [JsonProperty("commodityCount")]
        public long CommodityCount { get; set; }
        [JsonProperty("targetName")]
        public string TargetName { get; set; }
        [JsonProperty("targetType")]
        public string TargetType { get; set; }
        [JsonProperty("killCount")]
        public long KillCount { get; set; }
        [JsonProperty("passengerType")]
        public string PassengerType { get; set; }
        [JsonProperty("passengerCount")]
        public long PassengerCount { get; set; }
        [JsonProperty("passengerIsVIP")]
        public bool? PassengerIsVIP { get; set; }
        [JsonProperty("passengerIsWanted")]
        public bool? PassengerIsWanted { get; set; }
    }
    public enum GainType
    {
        Low,
        Med,
        High
    }
}
