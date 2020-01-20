using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CommanderInfo : IEvent
    {
        internal static CommanderInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommanderEvent(JsonConvert.DeserializeObject<CommanderInfo>(json, EliteAPI.Events.CommanderConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("FID")]
        public string Fid { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}
