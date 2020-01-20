using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class LiftoffInfo : EventBase
    {
        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; internal set; }

        internal static LiftoffInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeLiftoffEvent(JsonConvert.DeserializeObject<LiftoffInfo>(json, JsonSettings.Settings));
        }
    }
}