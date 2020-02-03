using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class HullDamageInfo : EventBase
    {
        [JsonProperty("Health")]
        public float Health { get; internal set; }

        [JsonProperty("PlayerPilot")]
        public bool PlayerPilot { get; internal set; }

        [JsonProperty("Fighter")]
        public bool Fighter { get; internal set; }

        internal static HullDamageInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeHullDamageEvent(JsonConvert.DeserializeObject<HullDamageInfo>(json, JsonSettings.Settings));
        }
    }
}