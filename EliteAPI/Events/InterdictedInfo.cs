using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class InterdictedInfo : EventBase
    {
        [JsonProperty("Submitted")]
        public bool Submitted { get; internal set; }

        [JsonProperty("Interdictor")]
        public string Interdictor { get; internal set; }

        [JsonProperty("Interdictor_Localised")]
        public string InterdictorLocalised { get; internal set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        internal static InterdictedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeInterdictedEvent(JsonConvert.DeserializeObject<InterdictedInfo>(json, JsonSettings.Settings));
        }
    }
}