using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FileheaderInfo : EventBase
    {
        [JsonProperty("part")]
        public long Part { get; internal set; }

        [JsonProperty("language")]
        public string Language { get; internal set; }

        [JsonProperty("gameversion")]
        public string Gameversion { get; internal set; }

        [JsonProperty("build")]
        public string Build { get; internal set; }

        internal static FileheaderInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeFileheaderEvent(JsonConvert.DeserializeObject<FileheaderInfo>(json, JsonSettings.Settings));
        }
    }
}