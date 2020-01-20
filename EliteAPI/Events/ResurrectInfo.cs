using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ResurrectInfo : IEvent
    {
        internal static ResurrectInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeResurrectEvent(JsonConvert.DeserializeObject<ResurrectInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Option")]
        public string Option { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
        [JsonProperty("Bankrupt")]
        public bool Bankrupt { get; internal set; }
    }
}
