using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ChangeCrewRoleInfo : EventBase
    {
        [JsonProperty("Role")]
        public string Role { get; internal set; }

        internal static ChangeCrewRoleInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeChangeCrewRoleEvent(JsonConvert.DeserializeObject<ChangeCrewRoleInfo>(json, JsonSettings.Settings));
        }
    }
}