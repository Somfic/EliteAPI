using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class NewCommanderInfo : EventBase
    {
        internal static NewCommanderInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeNewCommanderEvent(JsonConvert.DeserializeObject<NewCommanderInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Package")]
        public string Package { get; internal set; }
    }
}
