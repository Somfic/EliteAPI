using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class WingAddInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        internal static WingAddInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeWingAddEvent(JsonConvert.DeserializeObject<WingAddInfo>(json, JsonSettings.Settings));
        }
    }
}