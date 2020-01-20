using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class EngineerApplyInfo : EventBase
    {
        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Blueprint")]
        public string Blueprint { get; internal set; }

        [JsonProperty("Level")]
        public long Level { get; internal set; }

        [JsonProperty("Override")]
        public string Override { get; internal set; }

        internal static EngineerApplyInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeEngineerApplyEvent(JsonConvert.DeserializeObject<EngineerApplyInfo>(json, JsonSettings.Settings));
        }
    }
}