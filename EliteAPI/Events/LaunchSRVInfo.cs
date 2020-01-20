using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class LaunchSRVInfo : EventBase
    {
        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        internal static LaunchSRVInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeLaunchSRVEvent(JsonConvert.DeserializeObject<LaunchSRVInfo>(json, JsonSettings.Settings));
        }
    }
}