using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EscapeInterdictionInfo : EventBase
    {
        internal static EscapeInterdictionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEscapeInterdictionEvent(JsonConvert.DeserializeObject<EscapeInterdictionInfo>(json, JsonSettings.Settings));

        [JsonProperty("Interdictor")]
        public string Interdictor { get; internal set; }
        [JsonProperty("Interdictor_Localised")]
        public string InterdictorLocalised { get; internal set; }
        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }
    }
}
