using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ModuleInfoInfo : IEvent
    {
        internal static ModuleInfoInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeModuleInfoEvent(JsonConvert.DeserializeObject<ModuleInfoInfo>(json, EliteAPI.Events.ModuleInfoConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
}
