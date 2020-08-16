using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class RebootRepairEvent : EventBase
    {
        internal RebootRepairEvent() { }

        public static RebootRepairEvent FromJson(string json) => JsonConvert.DeserializeObject<RebootRepairEvent>(json);


        [JsonProperty("Modules")]
        public List<string> Modules { get; internal set; }

        
    }
}