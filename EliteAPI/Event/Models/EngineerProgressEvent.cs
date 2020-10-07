using System.Collections.Generic;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class EngineerProgressEvent : EventBase
    {
        internal EngineerProgressEvent() { }

        public static EngineerProgressEvent FromJson(string json) => JsonConvert.DeserializeObject<EngineerProgressEvent>(json);


        [JsonProperty("Engineers")]
        public List<Engineer> Engineers { get; internal set; }

        
    }
}