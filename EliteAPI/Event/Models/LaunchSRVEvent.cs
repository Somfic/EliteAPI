using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class LaunchSRVEvent : EventBase
    {
        internal LaunchSRVEvent() { }

        public static LaunchSRVEvent FromJson(string json) => JsonConvert.DeserializeObject<LaunchSRVEvent>(json);


        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        
    }
}