using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SearchAndRescueInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        internal static SearchAndRescueInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSearchAndRescueEvent(JsonConvert.DeserializeObject<SearchAndRescueInfo>(json, JsonSettings.Settings));
        }
    }
}