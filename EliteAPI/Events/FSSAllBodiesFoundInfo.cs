using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FSSAllBodiesFoundInfo : EventBase
    {
        [JsonProperty("SystemName")]
        public string SystemName { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static FSSAllBodiesFoundInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeFSSAllBodiesFoundEvent(JsonConvert.DeserializeObject<FSSAllBodiesFoundInfo>(json, JsonSettings.Settings));
        }
    }
}