using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class HullDamageInfo : IEvent
    {
        internal static HullDamageInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeHullDamageEvent(JsonConvert.DeserializeObject<HullDamageInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Health")]
        public double Health { get; internal set; }
        [JsonProperty("PlayerPilot")]
        public bool PlayerPilot { get; internal set; }
        [JsonProperty("Fighter")]
        public bool Fighter { get; internal set; }
    }
}
