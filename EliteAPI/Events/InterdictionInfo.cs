using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class InterdictionInfo : IEvent
    {
        internal static InterdictionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeInterdictionEvent(JsonConvert.DeserializeObject<InterdictionInfo>(json, EliteAPI.Events.InterdictionConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
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
