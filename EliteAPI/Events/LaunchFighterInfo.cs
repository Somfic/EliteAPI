using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class LaunchFighterInfo : EventBase
    {
        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        internal static LaunchFighterInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeLaunchFighterEvent(JsonConvert.DeserializeObject<LaunchFighterInfo>(json, JsonSettings.Settings));
        }
    }
}