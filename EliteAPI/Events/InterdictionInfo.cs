using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class InterdictionInfo : EventBase
    {
        internal static InterdictionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeInterdictionEvent(JsonConvert.DeserializeObject<InterdictionInfo>(json, JsonSettings.Settings));

        [JsonProperty("Success")]
        public bool Success { get; internal set; }
        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }
        [JsonProperty("Interdicted")]
        public string Interdicted { get; internal set; }
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }
        [JsonProperty("Power")]
        public string Power { get; internal set; }
    }
}
