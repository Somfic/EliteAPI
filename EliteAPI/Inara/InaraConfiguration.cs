using Newtonsoft.Json;

namespace EliteAPI.Inara
{
    public class InaraConfiguration
    {
        public InaraConfiguration(string apiKey, string appName, string appVersion)
        {
            ApiKey = apiKey;
            AppName = appName;
            AppVersion = appVersion;
        }
        [JsonProperty("appName")]
        public string AppName { get; internal set; }
        [JsonProperty("appVersion")]
        public string AppVersion { get; internal set; }
        [JsonProperty("isDeveloped")]
        public bool? IsDeveloped { get; internal set; }
        [JsonProperty("APIkey")]
        public string ApiKey { get; internal set; }
        [JsonProperty("commanderName")]
        public string CommanderName { get; internal set; }
        [JsonProperty("commanderFrontierID")]
        public string CommanderFrontierId { get; internal set; }
    }
}