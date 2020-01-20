using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CollectCargoInfo : IEvent
    {
        internal static CollectCargoInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCollectCargoEvent(JsonConvert.DeserializeObject<CollectCargoInfo>(json, EliteAPI.Events.CollectCargoConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }
        [JsonProperty("Stolen")]
        public bool Stolen { get; internal set; }
    }
}
