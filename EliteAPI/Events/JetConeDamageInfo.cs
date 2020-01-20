using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class JetConeDamageInfo : IEvent
    {
        internal static JetConeDamageInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeJetConeDamageEvent(JsonConvert.DeserializeObject<JetConeDamageInfo>(json, EliteAPI.Events.JetConeDamageConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Module")]
        public string Module { get; internal set; }
        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; internal set; }
    }
}
