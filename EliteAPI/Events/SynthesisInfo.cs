using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class SynthesisInfo : IEvent
    {
        internal static SynthesisInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSynthesisEvent(JsonConvert.DeserializeObject<SynthesisInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Materials")]
        public List<SynthesisMaterial> Materials { get; internal set; }
    }
}
