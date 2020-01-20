using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class QuitACrewInfo : EventBase
    {
        [JsonProperty("Captain")]
        public string Captain { get; internal set; }

        internal static QuitACrewInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeQuitACrewEvent(JsonConvert.DeserializeObject<QuitACrewInfo>(json, JsonSettings.Settings));
        }
    }
}