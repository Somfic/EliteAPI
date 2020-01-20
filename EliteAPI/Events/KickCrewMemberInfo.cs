using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class KickCrewMemberInfo : EventBase
    {
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }

        internal static KickCrewMemberInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeKickCrewMemberEvent(JsonConvert.DeserializeObject<KickCrewMemberInfo>(json, JsonSettings.Settings));
        }
    }
}