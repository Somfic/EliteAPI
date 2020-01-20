using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class JetConeBoostInfo : EventBase
    {
        internal static JetConeBoostInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeJetConeBoostEvent(JsonConvert.DeserializeObject<JetConeBoostInfo>(json, JsonSettings.Settings));

        [JsonProperty("BoostValue")]
        public double BoostValue { get; internal set; }
    }
}
