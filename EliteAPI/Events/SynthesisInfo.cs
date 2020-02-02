using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SynthesisInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Materials")]
        public List<SynthesisMaterial> Materials { get; internal set; }

        internal static SynthesisInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSynthesisEvent(JsonConvert.DeserializeObject<SynthesisInfo>(json, JsonSettings.Settings));
        }
    }
}