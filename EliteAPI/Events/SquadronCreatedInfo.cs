using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SquadronCreatedInfo : EventBase
    {
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        internal static SquadronCreatedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSquadronCreatedEvent(JsonConvert.DeserializeObject<SquadronCreatedInfo>(json, JsonSettings.Settings));
        }
    }
}