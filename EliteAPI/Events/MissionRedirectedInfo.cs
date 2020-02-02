using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MissionRedirectedInfo : EventBase
    {
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("NewDestinationStation")]
        public string NewDestinationStation { get; internal set; }

        [JsonProperty("NewDestinationSystem")]
        public string NewDestinationSystem { get; internal set; }

        [JsonProperty("OldDestinationStation")]
        public string OldDestinationStation { get; internal set; }

        [JsonProperty("OldDestinationSystem")]
        public string OldDestinationSystem { get; internal set; }

        internal static MissionRedirectedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMissionRedirectedEvent(JsonConvert.DeserializeObject<MissionRedirectedInfo>(json, JsonSettings.Settings));
        }
    }
}