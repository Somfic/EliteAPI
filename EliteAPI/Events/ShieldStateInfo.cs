using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ShieldStateInfo : EventBase
    {
        [JsonProperty("ShieldsUp")]
        public bool ShieldsUp { get; internal set; }

        internal static ShieldStateInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeShieldStateEvent(JsonConvert.DeserializeObject<ShieldStateInfo>(json, JsonSettings.Settings));
        }
    }
}