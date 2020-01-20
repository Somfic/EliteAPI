using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ShieldStateInfo : EventBase
    {
        internal static ShieldStateInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShieldStateEvent(JsonConvert.DeserializeObject<ShieldStateInfo>(json, JsonSettings.Settings));

        [JsonProperty("ShieldsUp")]
        public bool ShieldsUp { get; internal set; }
    }
}
