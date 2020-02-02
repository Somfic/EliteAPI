using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CrewMemberQuitsInfo : EventBase
    {
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        internal static CrewMemberQuitsInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCrewMemberQuitsEvent(JsonConvert.DeserializeObject<CrewMemberQuitsInfo>(json, JsonSettings.Settings));
        }
    }
}