using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MaterialDiscoveredInfo : EventBase
    {
        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("DiscoveryNumber")]
        public long DiscoveryNumber { get; internal set; }

        internal static MaterialDiscoveredInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMaterialDiscoveredEvent(JsonConvert.DeserializeObject<MaterialDiscoveredInfo>(json, JsonSettings.Settings));
        }
    }
}