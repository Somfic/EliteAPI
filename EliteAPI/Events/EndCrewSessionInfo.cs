using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class EndCrewSessionInfo : EventBase
    {
        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }

        internal static EndCrewSessionInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeEndCrewSessionEvent(JsonConvert.DeserializeObject<EndCrewSessionInfo>(json, JsonSettings.Settings));
        }
    }
}