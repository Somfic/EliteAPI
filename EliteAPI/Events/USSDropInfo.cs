using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class USSDropInfo : IEvent
    {
        internal static USSDropInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeUSSDropEvent(JsonConvert.DeserializeObject<USSDropInfo>(json, EliteAPI.Events.USSDropConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("USSType")]
        public string UssType { get; internal set; }
        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; internal set; }
        [JsonProperty("USSThreat")]
        public long UssThreat { get; internal set; }
    }
}
