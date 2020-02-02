using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CrewAssignInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("CrewID")]
        public long CrewId { get; internal set; }

        [JsonProperty("Role")]
        public string Role { get; internal set; }

        internal static CrewAssignInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCrewAssignEvent(JsonConvert.DeserializeObject<CrewAssignInfo>(json, JsonSettings.Settings));
        }
    }
}