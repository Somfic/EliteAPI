using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class JetConeDamageInfo : EventBase
    {
        [JsonProperty("Module")]
        public string Module { get; internal set; }

        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; internal set; }

        internal static JetConeDamageInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeJetConeDamageEvent(JsonConvert.DeserializeObject<JetConeDamageInfo>(json, JsonSettings.Settings));
        }
    }
}