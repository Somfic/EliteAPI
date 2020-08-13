using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class EngineerProgressEvent : EventBase
    {
        internal EngineerProgressEvent() { }
        [JsonProperty("Engineers")]
        public List<Engineer> Engineers { get; internal set; }

        
    }
}