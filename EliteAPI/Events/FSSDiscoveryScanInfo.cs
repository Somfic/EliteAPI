using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FSSDiscoveryScanInfo : EventBase
    {
        [JsonProperty("Progress")]
        public double Progress { get; internal set; }

        [JsonProperty("BodyCount")]
        public long BodyCount { get; internal set; }

        [JsonProperty("NonBodyCount")]
        public long NonBodyCount { get; internal set; }

        internal static FSSDiscoveryScanInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeFSSDiscoveryScanEvent(JsonConvert.DeserializeObject<FSSDiscoveryScanInfo>(json, JsonSettings.Settings));
        }
    }
}