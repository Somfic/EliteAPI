using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CrewMemberRoleChangeInfo : EventBase
    {
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        [JsonProperty("Role")]
        public string Role { get; internal set; }

        internal static CrewMemberRoleChangeInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCrewMemberRoleChangeEvent(JsonConvert.DeserializeObject<CrewMemberRoleChangeInfo>(json, JsonSettings.Settings));
        }
    }
}