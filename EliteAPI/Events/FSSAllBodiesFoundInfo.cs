using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FSSAllBodiesFoundInfo : EventBase
    {
        internal static FSSAllBodiesFoundInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFSSAllBodiesFoundEvent(JsonConvert.DeserializeObject<FSSAllBodiesFoundInfo>(json, JsonSettings.Settings));

        [JsonProperty("SystemName")]
        public string SystemName { get; internal set; }
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}
