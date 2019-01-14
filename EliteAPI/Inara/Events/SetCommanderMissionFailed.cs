using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class SetCommanderMissionFailed : IInaraEventData
    {
        public SetCommanderMissionFailed(long missionGameId)
        {
            MissionGameId = missionGameId;
        }

        [JsonProperty("missionGameID")]
        public long MissionGameId { get; set; }
    }
}
