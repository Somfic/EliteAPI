using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ResurrectInfo : EventBase
    {
        [JsonProperty("Option")]
        public string Option { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("Bankrupt")]
        public bool Bankrupt { get; internal set; }

        internal static ResurrectInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeResurrectEvent(JsonConvert.DeserializeObject<ResurrectInfo>(json, JsonSettings.Settings));
        }
    }
}