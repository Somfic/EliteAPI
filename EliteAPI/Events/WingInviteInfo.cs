using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class WingInviteInfo : EventBase
    {
        internal static WingInviteInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeWingInviteEvent(JsonConvert.DeserializeObject<WingInviteInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}
