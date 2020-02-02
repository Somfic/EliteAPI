using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CommanderInfo : EventBase
    {
        [JsonProperty("FID")]
        public string Fid { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        internal static CommanderInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCommanderEvent(JsonConvert.DeserializeObject<CommanderInfo>(json, JsonSettings.Settings));
        }
    }
}