using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class JetConeDamageInfo : EventBase
    {
        internal static JetConeDamageInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeJetConeDamageEvent(JsonConvert.DeserializeObject<JetConeDamageInfo>(json, JsonSettings.Settings));

        [JsonProperty("Module")]
        public string Module { get; internal set; }
        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; internal set; }
    }
}
