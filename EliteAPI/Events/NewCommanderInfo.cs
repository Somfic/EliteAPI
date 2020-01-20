using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class NewCommanderInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Package")]
        public string Package { get; internal set; }

        internal static NewCommanderInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeNewCommanderEvent(JsonConvert.DeserializeObject<NewCommanderInfo>(json, JsonSettings.Settings));
        }
    }
}