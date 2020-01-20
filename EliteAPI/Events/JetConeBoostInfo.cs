using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class JetConeBoostInfo : IEvent
    {
        internal static JetConeBoostInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeJetConeBoostEvent(JsonConvert.DeserializeObject<JetConeBoostInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("BoostValue")]
        public double BoostValue { get; internal set; }
    }
}
