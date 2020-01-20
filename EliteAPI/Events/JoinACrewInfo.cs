using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class JoinACrewInfo : EventBase
    {
        [JsonProperty("Captain")]
        public string Captain { get; internal set; }

        internal static JoinACrewInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeJoinACrewEvent(JsonConvert.DeserializeObject<JoinACrewInfo>(json, JsonSettings.Settings));
        }
    }
}