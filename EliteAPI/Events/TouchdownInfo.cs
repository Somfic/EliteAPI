using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class TouchdownInfo : EventBase
    {
        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        [JsonProperty("Latitude")]
        public float Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public float Longitude { get; internal set; }

        internal static TouchdownInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeTouchdownEvent(JsonConvert.DeserializeObject<TouchdownInfo>(json, JsonSettings.Settings));
        }
    }
}