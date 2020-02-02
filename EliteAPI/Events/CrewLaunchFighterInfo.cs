using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CrewLaunchFighterInfo : EventBase
    {
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        internal static CrewLaunchFighterInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCrewLaunchFighterEvent(JsonConvert.DeserializeObject<CrewLaunchFighterInfo>(json, JsonSettings.Settings));
        }
    }
}