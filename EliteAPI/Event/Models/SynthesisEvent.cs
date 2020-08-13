using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SynthesisEvent : EventBase
    {
        internal SynthesisEvent() { }
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Materials")]
        public List<SynthesisMaterial> Materials { get; internal set; }

        
    }
}