using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class LaunchDroneInfo : EventBase
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        internal static LaunchDroneInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeLaunchDroneEvent(JsonConvert.DeserializeObject<LaunchDroneInfo>(json, JsonSettings.Settings));
        }
    }
}