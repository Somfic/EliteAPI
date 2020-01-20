using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CrewMemberJoinsInfo : EventBase
    {
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        internal static CrewMemberJoinsInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCrewMemberJoinsEvent(JsonConvert.DeserializeObject<CrewMemberJoinsInfo>(json, JsonSettings.Settings));
        }
    }
}