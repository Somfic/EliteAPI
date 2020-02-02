using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CrewFireInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("CrewID")]
        public long CrewId { get; internal set; }

        internal static CrewFireInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCrewFireEvent(JsonConvert.DeserializeObject<CrewFireInfo>(json, JsonSettings.Settings));
        }
    }
}