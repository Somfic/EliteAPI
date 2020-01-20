using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PromotionInfo : IEvent
    {
        internal static PromotionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePromotionEvent(JsonConvert.DeserializeObject<PromotionInfo>(json, EliteAPI.Events.PromotionConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Federation")]
        public long Federation { get; internal set; }
    }
}
