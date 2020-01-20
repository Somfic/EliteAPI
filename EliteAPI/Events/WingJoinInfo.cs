using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class WingJoinInfo : EventBase
    {
        internal static WingJoinInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeWingJoinEvent(JsonConvert.DeserializeObject<WingJoinInfo>(json, JsonSettings.Settings));

        [JsonProperty("Others")]
        public List<string> Others { get; internal set; }
    }
}
