using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MissionAbandonedInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        internal static MissionAbandonedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMissionAbandonedEvent(JsonConvert.DeserializeObject<MissionAbandonedInfo>(json, JsonSettings.Settings));
        }
    }
}