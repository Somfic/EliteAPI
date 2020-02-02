using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DisbandedSquadronInfo : EventBase
    {
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        internal static DisbandedSquadronInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDisbandedSquadronEvent(JsonConvert.DeserializeObject<DisbandedSquadronInfo>(json, JsonSettings.Settings));
        }
    }
}