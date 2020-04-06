using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class SetCommanderMissionAbandoned : IInaraEventData
    {
        public SetCommanderMissionAbandoned(long missionGameId)
        {
            MissionGameId = missionGameId;
        }
        [JsonProperty("missionGameID")]
        public long MissionGameId { get; set; }
    }
}
