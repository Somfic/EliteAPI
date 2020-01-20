using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class LiftoffInfo : EventBase
    {
        internal static LiftoffInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLiftoffEvent(JsonConvert.DeserializeObject<LiftoffInfo>(json, JsonSettings.Settings));

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }
        [JsonProperty("Latitude")]
        public double Latitude { get; internal set; }
        [JsonProperty("Longitude")]
        public double Longitude { get; internal set; }
    }
}
