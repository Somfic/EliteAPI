using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class AppliedToSquadronInfo : EventBase
    {
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        internal static AppliedToSquadronInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeAppliedToSquadronEvent(JsonConvert.DeserializeObject<AppliedToSquadronInfo>(json, JsonSettings.Settings));
        }
    }
}