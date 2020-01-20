using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class USSDropInfo : EventBase
    {
        internal static USSDropInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeUSSDropEvent(JsonConvert.DeserializeObject<USSDropInfo>(json, JsonSettings.Settings));

        [JsonProperty("USSType")]
        public string UssType { get; internal set; }
        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; internal set; }
        [JsonProperty("USSThreat")]
        public long UssThreat { get; internal set; }
    }
}
