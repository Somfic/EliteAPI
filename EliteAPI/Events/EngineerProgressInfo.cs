using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class EngineerProgressInfo : EventBase
    {
        internal static EngineerProgressInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEngineerProgressEvent(JsonConvert.DeserializeObject<EngineerProgressInfo>(json, JsonSettings.Settings));

        [JsonProperty("Engineers")]
        public List<Engineer> Engineers { get; internal set; }
    }
}
