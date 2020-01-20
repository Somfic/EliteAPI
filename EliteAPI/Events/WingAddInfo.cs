using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class WingAddInfo : EventBase
    {
        internal static WingAddInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeWingAddEvent(JsonConvert.DeserializeObject<WingAddInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}
