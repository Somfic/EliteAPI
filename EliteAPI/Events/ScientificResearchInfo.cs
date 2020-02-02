using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ScientificResearchInfo : EventBase
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static ScientificResearchInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeScientificResearchEvent(JsonConvert.DeserializeObject<ScientificResearchInfo>(json, JsonSettings.Settings));
        }
    }
}