using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class SynthesisInfo : EventBase
    {
        internal static SynthesisInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSynthesisEvent(JsonConvert.DeserializeObject<SynthesisInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Materials")]
        public List<SynthesisMaterial> Materials { get; internal set; }
    }
}
