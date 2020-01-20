using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MaterialDiscardedInfo : EventBase
    {
        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static MaterialDiscardedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMaterialDiscardedEvent(JsonConvert.DeserializeObject<MaterialDiscardedInfo>(json, JsonSettings.Settings));
        }
    }
}