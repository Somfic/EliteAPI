using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class EngineerProgressInfo : IEvent
    {
        internal static EngineerProgressInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEngineerProgressEvent(JsonConvert.DeserializeObject<EngineerProgressInfo>(json, EliteAPI.Events.EngineerProgressConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Engineers")]
        public List<Engineer> Engineers { get; internal set; }
    }
}
