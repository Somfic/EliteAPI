using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class InterdictedInfo : IEvent
    {
        internal static InterdictedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeInterdictedEvent(JsonConvert.DeserializeObject<InterdictedInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Submitted")]
        public bool Submitted { get; internal set; }
        [JsonProperty("Interdictor")]
        public string Interdictor { get; internal set; }
        [JsonProperty("Interdictor_Localised")]
        public string InterdictorLocalised { get; internal set; }
        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }
    }
}
