using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class HullDamageInfo : EventBase
    {
        internal static HullDamageInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeHullDamageEvent(JsonConvert.DeserializeObject<HullDamageInfo>(json, JsonSettings.Settings));

        [JsonProperty("Health")]
        public double Health { get; internal set; }
        [JsonProperty("PlayerPilot")]
        public bool PlayerPilot { get; internal set; }
        [JsonProperty("Fighter")]
        public bool Fighter { get; internal set; }
    }
}
