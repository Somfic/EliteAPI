using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EngineerContributionInfo : IEvent
    {
        internal static EngineerContributionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEngineerContributionEvent(JsonConvert.DeserializeObject<EngineerContributionInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }
        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("Material")]
        public string Material { get; internal set; }
        [JsonProperty("Quantity")]
        public long Quantity { get; internal set; }
        [JsonProperty("TotalQuantity")]
        public long TotalQuantity { get; internal set; }
    }
}
