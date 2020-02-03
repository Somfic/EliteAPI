using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class JetConeBoostInfo : EventBase
    {
        [JsonProperty("BoostValue")]
        public float BoostValue { get; internal set; }

        internal static JetConeBoostInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeJetConeBoostEvent(JsonConvert.DeserializeObject<JetConeBoostInfo>(json, JsonSettings.Settings));
        }
    }
}