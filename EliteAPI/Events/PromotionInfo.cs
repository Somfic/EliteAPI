using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PromotionInfo : EventBase
    {
        internal static PromotionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePromotionEvent(JsonConvert.DeserializeObject<PromotionInfo>(json, JsonSettings.Settings));

        [JsonProperty("Federation")]
        public long Federation { get; internal set; }
    }
}
