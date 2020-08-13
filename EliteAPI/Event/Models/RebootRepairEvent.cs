using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class RebootRepairEvent : EventBase
    {
        internal RebootRepairEvent() { }
        [JsonProperty("Modules")]
        public List<string> Modules { get; internal set; }

        
    }
}