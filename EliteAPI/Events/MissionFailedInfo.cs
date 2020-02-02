using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MissionFailedInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        internal static MissionFailedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMissionFailedEvent(JsonConvert.DeserializeObject<MissionFailedInfo>(json, JsonSettings.Settings));
        }
    }
}