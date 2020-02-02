using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class EscapeInterdictionInfo : EventBase
    {
        [JsonProperty("Interdictor")]
        public string Interdictor { get; internal set; }

        [JsonProperty("Interdictor_Localised")]
        public string InterdictorLocalised { get; internal set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }

        internal static EscapeInterdictionInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeEscapeInterdictionEvent(JsonConvert.DeserializeObject<EscapeInterdictionInfo>(json, JsonSettings.Settings));
        }
    }
}