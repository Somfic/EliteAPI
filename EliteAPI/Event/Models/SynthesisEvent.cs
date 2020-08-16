using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SynthesisEvent : EventBase
    {
        internal SynthesisEvent() { }

        public static SynthesisEvent FromJson(string json) => JsonConvert.DeserializeObject<SynthesisEvent>(json);


        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Materials")]
        public List<SynthesisMaterial> Materials { get; internal set; }

        
    }
}