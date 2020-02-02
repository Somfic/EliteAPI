using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class InterdictionInfo : EventBase
    {
        [JsonProperty("Success")]
        public bool Success { get; internal set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }

        [JsonProperty("Interdicted")]
        public string Interdicted { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Power")]
        public string Power { get; internal set; }

        internal static InterdictionInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeInterdictionEvent(JsonConvert.DeserializeObject<InterdictionInfo>(json, JsonSettings.Settings));
        }
    }
}