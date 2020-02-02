using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DiscoveryScanInfo : EventBase
    {
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Bodies")]
        public long Bodies { get; internal set; }

        internal static DiscoveryScanInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDiscoveryScanEvent(JsonConvert.DeserializeObject<DiscoveryScanInfo>(json, JsonSettings.Settings));
        }
    }
}