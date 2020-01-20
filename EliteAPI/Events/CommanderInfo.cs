using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CommanderInfo : EventBase
    {
        internal static CommanderInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommanderEvent(JsonConvert.DeserializeObject<CommanderInfo>(json, JsonSettings.Settings));

        [JsonProperty("FID")]
        public string Fid { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}
