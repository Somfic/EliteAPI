using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MiningRefinedInfo : IEvent
    {
        internal static MiningRefinedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMiningRefinedEvent(JsonConvert.DeserializeObject<MiningRefinedInfo>(json, EliteAPI.Events.MiningRefinedConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }
    }
}
